using Enum.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Mafia.Web.MVC;

/// <summary>
/// Глобальный контроллер для сервиса
/// </summary>
public abstract class MafiaOnlineController : ControllerBase
{
    protected AppLogger _logger { get; }

    public MafiaOnlineController(ILoggerFactory loggerFactory)
    {
        var baseLogger = loggerFactory.CreateLogger(this.GetType());
        _logger = new AppLogger(baseLogger);
    }
    
    
    /// <summary>
    /// Возвращает JSON на запросы.
    /// </summary>
    /// <param name="value">Обьект для сериализации в JSON.</param>
    protected ContentResult JsonContent(object value, bool isAllowHtml = false)
    {
        var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(value);

        return new ContentResult
        {
            Content = jsonString,
            ContentType = "application/json"
        };
    }
}

/// <summary>
/// Класс для создания логов
/// </summary>
public class AppLogger
{
    private readonly ILogger _logger;
    
    public AppLogger(ILogger logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Логирует в зависимости от статуса
    /// </summary>
    /// <param name="message">Сообщение</param>
    /// <param name="state">Статус</param>
    public void Log(string message, ExecuteState state)
    {
        if (state == ExecuteState.Error)
            _logger.LogError(message);
        if (state == ExecuteState.OK)
            _logger.LogInformation(message);
        _logger.LogDebug(message);
    }
}