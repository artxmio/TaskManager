using TaskManager.Model.TaskModel;

namespace TaskManager.Model.UserModel;

public class User : IEntityModel
{
    public int UserId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    public virtual ICollection<Model.TaskModel.Task> Tasks { get; set; }
}
