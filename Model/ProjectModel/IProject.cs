namespace TaskManager.Model.ProjectModel;

public interface IProject
{
    string Title { get; set; }
    string Description { get; set; }
    int CountParticipants { get; set; }
    bool IsComplete { get; set; }
}