using DomainModel.Models.Model.User;

namespace Models.DefaultModels.User;

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