using TaskManager.Model.ProjectModel;
using TaskManager.Model.UserModel;

namespace TaskManager.Model.TaskModel;

public class Task
{
    public int TaskId { get; set; }
    public required string Description { get; set; }

    // Внешние ключи
    public int ProjectId { get; set; }
    public int UserId { get; set; }

    // Навигационные свойства
    public virtual Project Project { get; set; }
    public virtual User User { get; set; }
}
