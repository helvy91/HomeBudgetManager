﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeBudgetManager.Infrastructure
{
    public class BillOcrManager
    {
        private readonly IComputerVisionClient _client;

        public BillOcrManager(IComputerVisionClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<BillOcrResult> GetBillOcrResult(byte[] imageBuffer)
        {
            var recognitionResult = await _client.RecognizeTextAsync(imageBuffer);
            if (!recognitionResult.Lines.Any())
            {
                throw new ArgumentException("Provided image does not contain text or OCR failed to recognize it.");
            }

            return GetBill(recognitionResult.Lines);            
        }

        private BillOcrResult GetBill(List<TextRecognitionLine> lines)
        {
            return new BillOcrResult()
            {
                Lines = GetBillLines(lines),
                SourceLines = lines.Select(x => x.Text).ToList()
            };
        }

        private List<BillOcrLine> GetBillLines(List<TextRecognitionLine> lines)
        {
            return lines
                .OrderBy(x => x.BoundingBox.PointA.Y)
                .GroupBy(x => Math.Round(x.BoundingBox.PointA.Y / 15.0) * 15.0)
                .Select(x => new BillOcrLine()
                {
                    ProductName = GetProductName(x),
                    ProductPrice = GetProductPrice(x)
                }).ToList();
        }

        private string GetProductName(IGrouping<double, TextRecognitionLine> lines)
        {
            return string.Join(
                " ", 
                lines
                .Where(x => !HasPrice(x.Text))
                .Select(x => x.Text));
        }

        private string GetProductPrice(IGrouping<double, TextRecognitionLine> lines)
        {
            return string.Join(
                " ",
                lines
                .Where(x => HasPrice(x.Text))
                .Select(x => x.Text));
        }

        private bool HasPrice(string text)
            => Regex.IsMatch(text.Replace(" ", ""), @"(\d+\,\d{1,2})");
    }
}
