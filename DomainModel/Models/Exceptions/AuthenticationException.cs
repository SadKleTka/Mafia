using Models.DefaultModels;

namespace Models.Exceptions;

public class AuthenticationException : Exception
{
    public ExecuteResult Result { get; }

    public AuthenticationException(ExecuteResult result) 
        : base(result.Message)
    {
        Result = result;
    }
}