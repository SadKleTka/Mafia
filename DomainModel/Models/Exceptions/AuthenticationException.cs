using Enum.Enums;
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

    public AuthenticationException(String message) : base(message)
    {
        Result = new ExecuteResult
        {
            State = ExecuteState.Error,
            Message = message,
            MessageCode = "409"
        };
    }
}