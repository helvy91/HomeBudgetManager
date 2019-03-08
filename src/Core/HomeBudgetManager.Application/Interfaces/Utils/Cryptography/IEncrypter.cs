namespace HomeBudgetManager.Application.Interfaces.Utils.Cryptography
{
    public interface IEncrypter
    {
        string GetSalt(string value);
        string GetHash(string value, string salt);
    }
}
