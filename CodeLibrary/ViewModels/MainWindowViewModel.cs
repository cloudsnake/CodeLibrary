using CodeLibrary.Data;
using CodeLibrary.Data.Service;
using CodeLibrary.Helper;
using CodeLibrary.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


//<i:EventTrigger EventName = "MouseDoubleClick" >
//< prism:InvokeCommandAction Command = "{Binding DoubleClickCommand}"
//CommandParameter="{Binding ElementName=tvTreeView,Path=SelectedItem}" />
//</i:EventTrigger>

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

        private long _countDoc;

        public long CountDoc
        {
            get { return _countDoc; }
            set { SetProperty(ref _countDoc, value); }
        }
        public DelegateCommand<ItemTreeData> SelectItemChangeCommand { get; private set; }
        public DelegateCommand RefreshCommand { get; private set; }
        public DelegateCommand AddNewUpdate { get; private set; }
        public DelegateCommand UpdateCommand { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }
        public DelegateCommand<ItemTreeData> DoubleClickCommand { get; private set; }
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            InitTreeView();
            AddNewUpdate = new DelegateCommand(OnAddUpdate);
            RefreshCommand = new DelegateCommand(OnRefresh);
            UpdateCommand = new DelegateCommand(OnUpdate);
            DeleteCommand = new DelegateCommand(OnDelete);
            //            DoubleClickCommand = new DelegateCommand<ItemTreeData>(OnDoubleClick);
            SelectItemChangeCommand = new DelegateCommand<ItemTreeData>(OnSelectItem);
            var code = DataHelper.Instance.Current.Select<CodeDocument>();
            var query = code.Where(t => t.Id > 0).ToList();
            GetDocumentCount();
        }

        public async void GetDocumentCount()
        {
            var count = await CodeDocumentService.GetCodeDocumentCount();
            CountDoc = count;
        }
        //public void OnDoubleClick(ItemTreeData itemTreeData)
        //{
        //    if (itemTreeData == null || itemTreeData.itemId <= 0)
        //    {
        //        return;
        //    }
        //    var parameters = new NavigationParameters();
        //    parameters.Add("Id", itemTreeData.itemId);
        //    _regionManager.RequestNavigate("ContentRegion", "CodeInfo", parameters);
        //}
        private async void OnDelete()
        {
            if (SelectedCodeId <= 0)
            {
                return;
            }
            var cd = await CodeDocumentService.GetCodeDocumentById(SelectedCodeId);
            await CodeDocumentService.DeleteCodeDocument(cd);
            OnRefresh();
        }

        private int SelectedCodeId = 0;

        private void OnUpdate()
        {
            if (SelectedCodeId <= 0)
            {
                return;
            }
            var parameters = new NavigationParameters();
            parameters.Add("Id", SelectedCodeId);

            _regionManager.RequestNavigate("ContentRegion", "AddUpdateCodeDocument", parameters);

        }
        private void OnSelectItem(ItemTreeData itemTreeData)
        {
            if (itemTreeData == null || itemTreeData.itemId <= 0)
            {
                SelectedCodeId = 0;
                return;
            }

            SelectedCodeId = itemTreeData.itemId;
            var parameters = new NavigationParameters();
            parameters.Add("Id", itemTreeData.itemId);
            _regionManager.RequestNavigate("ContentRegion", "CodeInfo", parameters);
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
            GetTreeData();
        }
        private async void GetTreeData()
        {
            var list = await CodeDocumentService.GetCodeDocumentTitlesByTitle("");

            string _root = "";
            var rootChild = new ItemTreeData();
            var _list = new List<ItemTreeData>();

            foreach (var s in list)
            {
                var ss = EnumHelper.GetEnumName<ProgrammingLanguage>(s.ProgrammingLanguageId);
                if (_root != ss)
                {
                    rootChild = new ItemTreeData();
                    rootChild.titleName = ss;
                    rootChild.itemId = 0;
                    _list.Add(rootChild);
                    _root = ss;
                }
                var child = new ItemTreeData();
                child.titleName = s.Title;
                child.itemId = s.Id;
                rootChild.Children.Add(child);
            }
            //itemTreeDataList.Clear();
            //ItemTreeDataList.Clear();
            try
            {
                ItemTreeDataList = new ObservableCollection<ItemTreeData>(_list);
            }
            catch (Exception e)
            {
            }
        }
        //public void ViewCode(int id)
        //{            
        //    //删除原有view
        //    //if (_regionManager.Regions["ContentRegion"] != null)
        //    //{
        //    //    List<object> views = new List<object>(_regionManager.Regions["ContentRegion"].Views);
        //    //    foreach (object view in views)
        //    //    {
        //    //        _regionManager.Regions["ContentRegion"].Remove(view);
        //    //    }
        //    //}
        //    var parameters = new NavigationParameters();
        //    parameters.Add("Id", id);
        //    _regionManager.RequestNavigate("ContentRegion", "CodeView",parameters);
        //}
    }
}
