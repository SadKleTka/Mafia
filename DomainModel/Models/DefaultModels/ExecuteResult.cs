using Enum.Enums;

namespace Models.DefaultModels;

/// <summary>
/// Результат выполнения команды
/// </summary>
public class ExecuteResult
{
    /// <summary>
    /// Статус выполнения метода на сервисе
    /// </summary>
    public ExecuteState State { get; set; }

    /// <summary>
    /// Понятный текст возникшей ошибки на сервисе
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Код сообщения для локализации на вызываемой стороне
    /// </summary>
    public string MessageCode { get; set; }

    /// <summary>
    /// State == ExecuteState.OK
    /// </summary>
    public bool IsOK => State == ExecuteState.OK;


    public static ExecuteResult OK()
    {
        return new ExecuteResult { State = ExecuteState.OK };
    }

    public static ExecuteResult OK(string message)
    {
        return new ExecuteResult { State = ExecuteState.OK, Message = message };
    }

    public static ExecuteResult Error(string errorMessage, string messageCode = null)
    {
        return new ExecuteResult() { State = ExecuteState.Error, Message = errorMessage, MessageCode = messageCode };
    }

    public static ExecuteResult Error(string errorMessage, int errorCode)
    {
        return Error(errorMessage, errorCode.ToString());
    }

    public static TR Error<TR>(string errorMessage) where TR : ExecuteResult, new()
    {
        return new TR { State = ExecuteState.Error, Message = errorMessage };
    }

    public static TR Error<TR>(string errorMessage, int errorCode) where TR : ExecuteResult, new()
    {
        return new TR { State = ExecuteState.Error, Message = errorMessage, MessageCode = errorCode.ToString() };
    }

    public static TR Error<TR>(Exception exception, string beforeMessage = "") where TR : ExecuteResult, new()
    {
        return Error<TR>(beforeMessage + exception.Message);
    }

    public static TR Error<TR>(string errorMessage, string messageCode) where TR : ExecuteResult, new()
    {
        return new TR { State = ExecuteState.Error, Message = errorMessage, MessageCode = messageCode };
    }

    public static TR OK<TR>(Action<TR> action) where TR : ExecuteResult, new()
    {
        var result = new TR { State = ExecuteState.OK };
        action(result);
        return result;
    }

    public static ExecuteResult Error(Exception exception)
    {
        return Error($"{exception.Message} {exception?.InnerException?.Message}");
    }
}