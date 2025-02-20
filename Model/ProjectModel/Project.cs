using System.Collections.Specialized;
using System.ComponentModel;
using TaskManager.Model.TaskModel;

namespace TaskManager.Model.ProjectModel;

public class Project : INotifyPropertyChanged, IEntityModel
{
    private int _projectId;
    private string _title;
    private string _description;
    private int _countParticipants;
    private bool _isComplete;

    public int ProjectId
    {
        get { return _projectId; }
        set
        {
            if (_projectId != value)
            {
                _projectId = value;
                OnPropertyChanged(nameof(ProjectId));
            }
        }
    }

    public string Title
    {
        get { return _title; }
        set
        {
            if (_title != value)
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }

    public string Description
    {
        get { return _description; }
        set
        {
            if (_description != value)
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }

    public int CountParticipants
    {
        get { return _countParticipants; }
        set
        {
            if (_countParticipants != value)
            {
                _countParticipants = value;
                OnPropertyChanged(nameof(CountParticipants));
            }
        }
    }

    public bool IsComplete
    {
        get { return _isComplete; }
        set
        {
            if (_isComplete != value)
            {
                _isComplete = value;
                OnPropertyChanged(nameof(IsComplete));
            }
        }
    }

    public virtual ICollection<Model.TaskModel.Task> Tasks { get ; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
