using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mafia.Web.MVC;

public abstract class MafiaOnlineController : ControllerBase
{
    /// <summary>
    /// Возвращает JSON на запросы.
    /// </summary>
    /// <param name="value">Обьект для сериализации в JSON.</param>
    protected ContentResult JsonContent(object value, bool isAllowHtml = false)
    {
        return JsonContent(JsonConvert.SerializeObject(value), isAllowHtml);
    }
}