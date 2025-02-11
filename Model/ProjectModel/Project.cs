namespace TaskManager.Model.ProjectModel;

public class Project : IProject
{
    public string Title { get; set; }
    public string Description { get; set; }
    public uint CountParticipants { get; set; }
    public bool IsComplete { get; set; }

    //basic constructor
    public Project()
    {
        Title = "";
        Description = "";
        CountParticipants = 0;
        IsComplete = false;
    }

    //constructor with parametrs
    public Project(string title, string descriprion, uint countPartisipants, bool isComplete)
    {
        Title = title;
        Description = descriprion;
        CountParticipants = countPartisipants;
        IsComplete = isComplete;
    }
}
