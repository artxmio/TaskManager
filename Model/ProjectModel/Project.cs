namespace TaskManager.Model.ProjectModel;

public class Project
{
    public int ProjectId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public int CountParticipants { get; set; }
    public bool IsComplete { get; set; }

    public virtual ICollection<Task> Tasks { get ; set; }
}
