namespace TaskManager.Model.ProjectModel;

public class Project
{
    public int ProjectId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CountParticipants { get; set; }
    public bool IsComplete { get; set; }
}
