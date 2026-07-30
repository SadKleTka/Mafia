using Microsoft.AspNetCore.Mvc;

namespace Mafia.Web.MVC;

public abstract class MafiaOnlineController : ControllerBase
{
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