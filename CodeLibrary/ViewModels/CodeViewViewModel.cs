using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Regions;

namespace CodeLibrary.ViewModels
{
    public class CodeViewViewModel : BindableBase, INavigationAware
    {

        private string _codeTitle;
        private string _codeInfo;
        private string _data;

        public string CodeTitle
        {
            get { return _codeTitle; }
            set { SetProperty(ref _codeTitle, value); }
        }

        public string CodeInfo
        {
            get { return _codeInfo; }
            set { SetProperty(ref _codeInfo, value); }
        }

        public string Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }

        private int _id;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                SetProperty(ref _id,value);
            }
        }

        public CodeViewViewModel()
        {
            //_title = Guid.NewGuid().ToString();
            //_info = Guid.NewGuid().ToString();
            //_data = Guid.NewGuid().ToString();
        }

        //public void OnNavigatedTo(NavigationContext navigationContext)
        //{
        //    var id = navigationContext.Parameters["Id"].ToString();
        //    if (!string.IsNullOrWhiteSpace(id))
        //    {
        //        int _id = 0;
        //        int.TryParse(id, out _id);

        //        CodeTitle = Guid.NewGuid().ToString();
        //        CodeInfo = Guid.NewGuid().ToString();
        //        Data = Guid.NewGuid().ToString();

        //    }
        //}
        //public bool IsNavigationTarget(NavigationContext navigationContext)
        //{
        //    return true;

        //}
        //public void OnNavigatedFrom(NavigationContext navigationContext)
        //{

        //}
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var obj = navigationContext.Parameters["Id"];
            var sid = obj.ToString();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

    }
}
