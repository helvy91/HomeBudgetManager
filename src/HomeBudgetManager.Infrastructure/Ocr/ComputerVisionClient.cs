﻿using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetManager.Infrastructure
{
    public class ComputerVisionClient : IComputerVisionClient
    {
        private readonly IComputerVisionConfiguration _config;
        private readonly Microsoft.Azure.CognitiveServices.Vision.ComputerVision.ComputerVisionClient _client;

        public ComputerVisionClient()
        {
            _config = new ComputerVisionConfiguration();

            _client = new Microsoft.Azure.CognitiveServices.Vision.ComputerVision.ComputerVisionClient(
                new ApiKeyServiceClientCredentials(_config.SubscriptionKey),
                new System.Net.Http.DelegatingHandler[] { });
            _client.Endpoint = _config.ApiUrl;
        }

        public async Task<TextRecognitionResult> RecognizeTextAsync(byte[] imageBuffer)
        {
            var headers = await ExecuteRecognizingOperation(imageBuffer);
            var result = await GetRecognizingOperationResult(headers);

            return GetTextRecognitionResult(result);
        }

        private async Task<RecognizeTextInStreamHeaders> ExecuteRecognizingOperation(byte[] buffer)
        {
            using (var ms = new MemoryStream(buffer))
            {
                return await _client.RecognizeTextInStreamAsync(ms, TextRecognitionMode.Printed);
            }
        }

        private async Task<TextOperationResult> GetRecognizingOperationResult(RecognizeTextInStreamHeaders headers)
        {
            string operationId = headers.OperationLocation.Substring(headers.OperationLocation.Length - 36);

            var result = await _client.GetTextOperationResultAsync(operationId);
            for (int i = 0; i < 10; i++)
            {
                if (result.Status == TextOperationStatusCodes.Failed)
                {
                    throw new ComputerVisionErrorException("Text recognition operation failed.");
                }
                    
                if (result.Status == TextOperationStatusCodes.Succeeded)
                {
                    return result;
                }
                else
                {
                    await Task.Delay(2000);
                    result = await _client.GetTextOperationResultAsync(operationId);
                }
            }

            throw new TimeoutException("Cognitive Services did not respond properly in estimated time.");
        }

        private TextRecognitionResult GetTextRecognitionResult(TextOperationResult result)
        {
            var lines = result.RecognitionResult.Lines
                .Select(x => new TextRecognitionLine()
                {
                    BoundingBox = BoundingBox.Create(x.BoundingBox.ToList()),
                    Text = x.Text,
                    Words = x.Words.Select(y => new TextRecognitionWord()
                    {
                        BoundingBox = BoundingBox.Create(x.BoundingBox.ToList()),
                        Text = y.Text
                    }).ToList()
                }).ToList();

            return new TextRecognitionResult()
            {
                Lines = lines
            };
        }
    }
}
