using Microsoft.EntityFrameworkCore;

namespace BookKart.Core.Infrastructure.EFException;

public class DuplicateKeyException<TEntity> : DbUpdateException
  where TEntity : class
{
    private string _message = $"{typeof(TEntity).Name} cannot be saved as duplicate record exists.";
    public override string Message => _message ?? (_message = ConvertToSentence(GetType().Name, ErrorCode));

    private string _errorCode = "APP-ERROR-005";

    /// <summary>
    /// Error code helps distringuishing same types of errors in different context.
    /// </summary>
    public string ErrorCode => _errorCode;

    public DuplicateKeyException()
    {
    }

    static string ConvertToSentence(string message, string errorCode)
    {
        return errorCode + ": " + message;
    }
}

