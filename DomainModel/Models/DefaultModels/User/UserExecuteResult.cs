using DomainModel.Models.Model.User;

namespace Models.DefaultModels.User;

/// <summary>
/// Результат выполнения команды с возвращаемым списком пользователей
/// </summary>
public class UserExecuteResult : ExecuteResult
{
    public UserExecuteResult (IEnumerable<UsersResponse> user)
    {
        User = user;
    }
    public UserExecuteResult()
    {}
    public IEnumerable<UsersResponse> User { get; set; }
}