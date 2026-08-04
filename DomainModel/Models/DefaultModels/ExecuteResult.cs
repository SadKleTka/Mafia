using Enum.Enums;

namespace Models.DefaultModels;

/// <summary>
/// Результат выполнения команды
/// </summary>
public class ExecuteResult
{
    public ExecuteResult(string message, ExecuteState state, string code)
    {
        Message = message;
        State = state;
        MessageCode = code;
    }
    public ExecuteResult()
    {}
    
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
    
    /// <summary>
    /// State == ExecuteState.Created
    /// </summary>
    public bool IsCreated => State == ExecuteState.Created;
    
    /// <summary>
    /// State == ExecuteState.Deleted
    /// </summary>
    public bool IsDeleted => State == ExecuteState.Deleted;
    
    /// <summary>
    /// State == ExecuteState.Error
    /// </summary>
    public bool IsError => State == ExecuteState.Error;
    

}