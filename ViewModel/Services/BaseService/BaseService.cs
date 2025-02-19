using System.Collections.ObjectModel;
using System.Windows;
using TaskManager.Model;

namespace TaskManager.ViewModel.Services.BaseService;

public abstract class BaseService 
{
    protected ApplicationContext.ApplicationContext _context;

    public ObservableCollection<IEntityModel> Data {  get; set; }
    public IEntityModel? Selected { get; set; }

    protected BaseService(ApplicationContext.ApplicationContext context)
    {
        _context = context;
        Data = [];
    }

    public abstract void Add();
    public abstract void Delete();

    public virtual void Save()
    {
        _context.SaveChanges();
        MessageBox.Show("Changes was saved", "Success", MessageBoxButton.OK);
    }
}
