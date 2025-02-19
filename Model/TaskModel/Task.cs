using TaskManager.Model.ProjectModel;
using TaskManager.Model.UserModel;

namespace TaskManager.Model.TaskModel;

public class Task
{
    public int TaskId { get; set; }
    public string Title { get; set; }

    public int ProjectId { get; set; }
    public int UserId { get; set; }

    public virtual Project Project { get; set; }
    public virtual User User { get; set; }
}
