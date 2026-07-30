namespace Enum.Enums;

/// <summary>
/// Статус выполнения метода на сервисе
/// </summary>
public enum ExecuteState
{
    /// <summary>
    /// Выполнено
    /// </summary>
    OK,
    /// <summary>
    /// Выполнено с ошибками
    /// </summary>
    Error,
    /// <summary>
    /// Заблокировано
    /// </summary>
    Blocked
}