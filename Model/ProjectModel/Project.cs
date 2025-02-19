﻿using System.Collections.Specialized;
using System.ComponentModel;
using TaskManager.Model.TaskModel;

namespace TaskManager.Model.ProjectModel;

public class Project : IEntityModel
{
    public int ProjectId
    {
        get;
        set;
    }
    public string Title
    {
        get;
        set;
    }
    public string Description
    {
        get;
        set;
    }
    public int CountParticipants
    {
        get;
        set;
    }
    public bool IsComplete
    {
        get;
        set;
    }

    public virtual ICollection<Model.TaskModel.Task> Tasks { get ; set; }
}
