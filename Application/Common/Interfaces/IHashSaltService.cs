namespace Application.Common.Interfaces;

public interface IHashSaltService
{
    string ComputeSalt();
    
    string ComputeHash(string sourceValue, string forSalt);
}