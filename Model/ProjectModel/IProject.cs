namespace TaskManager.Model.ProjectModel;

public interface IProject
{
    string Title { get; set; }
    string Description { get; set; }
    uint CountParticipants { get; set; }
    bool Complete { get; set; }
}