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

        }
    }
}
