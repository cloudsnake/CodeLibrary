using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            InitTreeView();
            AddNewUpdate = new DelegateCommand(OnAddUpdate);
            var code = DataHelper.Instance.Current.Select<CodeDocument>();
            var query = code.Where(t => t.Id > 0).ToList();
        }

        private void OnAddUpdate()
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(AddUpdateCodeDocument));

        }
        // Item的树形结构
        private ObservableCollection<ItemTreeData> itemTreeDataList;
        public ObservableCollection<ItemTreeData> ItemTreeDataList
        {
            get { return itemTreeDataList; }
            set { SetProperty(ref itemTreeDataList, value); }
        }

        private void InitTreeView()
        {
            // 添加树形结构
            ItemTreeData item = GetTreeData();
            if (itemTreeDataList == null)
            {
                itemTreeDataList = new ObservableCollection<ItemTreeData>();
            }
            ItemTreeDataList.Clear();

            ItemTreeDataList.Add(item);
        }

        private ItemTreeData GetTreeData()
        {
            var itd = new ItemTreeData();
            itd.titleName = "C++";
            itd.itemId = 0;
            itd.itemParent = 0;

            return itd;
        }


    }
}
