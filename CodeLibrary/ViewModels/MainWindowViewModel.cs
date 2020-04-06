using System.Collections.Generic;
using System.Windows.Input;
using CodeLibrary.Data;
using CodeLibrary.Model;
using CodeLibrary.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace CodeLibrary.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager _regionManager;

        private string _title = "代码·库";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public DelegateCommand AddNewUpdate { get; private set; }
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            AddNewUpdate = new DelegateCommand(OnAddUpdate);
            var code = DataHelper.Instance.Current.Select<CodeDocument>();
            var query = code.Where(t => t.Id > 0).ToList();
        }

        private void OnAddUpdate()
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(AddUpdateCodeDocument));

        }
    }
}
