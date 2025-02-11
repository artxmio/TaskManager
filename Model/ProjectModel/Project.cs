namespace TaskManager.Model.ProjectModel;

public class Project : IProject
{
    public string Title { get; set; }
    public string Description { get; set; }
    public uint CountParticipants { get; set; }
    public bool Complete { get; set; }

    public Project()
    {
        Title = "";
        Description = "";
        CountParticipants = 0;
        Complete = false;
    }
}
