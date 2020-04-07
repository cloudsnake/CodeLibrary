using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CodeLibrary.Data;
using CodeLibrary.Data.Service;
using CodeLibrary.Helper;
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
        public DelegateCommand<ItemTreeData> SelectItemChangeCommand { get; private set; }
        public DelegateCommand RefreshCommand { get; private set; }
        public DelegateCommand AddNewUpdate { get; private set; }
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            InitTreeView();
            AddNewUpdate = new DelegateCommand(OnAddUpdate);
            RefreshCommand = new DelegateCommand(OnRefresh);
            SelectItemChangeCommand = new DelegateCommand<ItemTreeData>(OnSelectItem);
            var code = DataHelper.Instance.Current.Select<CodeDocument>();
            var query = code.Where(t => t.Id > 0).ToList();
        }

        private void OnSelectItem(ItemTreeData itemTreeData)
        {
            if (itemTreeData == null || itemTreeData.itemId <= 0)
            {
                return;
            }
            var parameters = new NavigationParameters();
            parameters.Add("Id", itemTreeData.itemId);

            _regionManager.RequestNavigate("ContentRegion", "CodeView", parameters);
        }
        private void OnRefresh()
        {
            InitTreeView();
        }
        private void OnAddUpdate()
        {
            var parameters = new NavigationParameters();
            parameters.Add("Id", Guid.NewGuid().ToString());

            _regionManager.RequestNavigate("ContentRegion", "AddUpdateCodeDocument", parameters);

           // _regionManager.RegisterViewWithRegion("ContentRegion", typeof(AddUpdateCodeDocument));
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
            if (itemTreeDataList == null)
            {
                itemTreeDataList = new ObservableCollection<ItemTreeData>();
            }
            ItemTreeDataList.Clear();
            GetTreeData();
        }
        private async void GetTreeData()
        {
            var list = await CodeDocumentService.GetCodeDocumentTitlesByTitle("");

            string _root = "";
            var rootChild = new ItemTreeData();

            foreach (var s in list)
            {
                var ss = EnumHelper.GetEnumName<ProgrammingLanguage>(s.ProgrammingLanguageId);
                if (_root != ss)
                {
                    rootChild = new ItemTreeData();
                    rootChild.titleName = ss;
                    rootChild.itemId = 0;
                    ItemTreeDataList.Add(rootChild);
                    _root = ss;
                }
                var child = new ItemTreeData();
                child.titleName = s.Title;
                child.itemId = s.Id;
                rootChild.Children.Add(child);


            }

        }
        public void ViewCode(int id)
        {            
            //删除原有view
            //if (_regionManager.Regions["ContentRegion"] != null)
            //{
            //    List<object> views = new List<object>(_regionManager.Regions["ContentRegion"].Views);
            //    foreach (object view in views)
            //    {
            //        _regionManager.Regions["ContentRegion"].Remove(view);
            //    }
            //}
            var parameters = new NavigationParameters();
            parameters.Add("Id", id);
            _regionManager.RequestNavigate("ContentRegion", "CodeView",parameters);
        }
    }
}
