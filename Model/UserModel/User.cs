namespace TaskManager.Model.UserModel;

public class User
{
    public int UserId { get; set; }
    public required string Login { get; set; }
    public required string Pasword { get; set; }

    public virtual ICollection<Task> Tasks { get; set; }
}
