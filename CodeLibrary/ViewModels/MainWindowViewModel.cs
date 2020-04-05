using CodeLibrary.Data;
using CodeLibrary.Model;
using Prism.Mvvm;

namespace CodeLibrary.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "代码·库";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            var code = DataHelper.Instance.Current.Select<CodeDocument>();
            var query = code.Where(t => t.Id > 0).ToList();

        }
    }
}
