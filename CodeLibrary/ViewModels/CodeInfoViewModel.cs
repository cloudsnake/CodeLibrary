using CodeLibrary.Data.Service;
using CodeLibrary.Helper;
using CodeLibrary.Model;
using Prism.Mvvm;
using Prism.Regions;

namespace CodeLibrary.ViewModels
{
    public class CodeInfoViewModel : BindableBase, INavigationAware
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
                SetProperty(ref _id, value);
            }
        }

        public CodeInfoViewModel()
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var obj = navigationContext.Parameters["Id"];
            var sid = obj.ToString();
            int _id = 0;
            int.TryParse(sid, out _id);
            if (_id > 0)
            {
                GetCodeInfo(_id);
            }
        }

        private async void GetCodeInfo(int id)
        {
            var dc = await CodeDocumentService.GetCodeDocumentById(id);
            CodeTitle = dc.Title;
            //CodeInfo = dc.KeyWords;
            string spl = EnumHelper.GetEnumName<ProgrammingLanguage>(dc.ProgrammingLanguageId);
            string spt = EnumHelper.GetEnumName<ProgrammingType>(dc.ProgrammingTypeId);
            CodeInfo = $"语言: {spl}   框架: {spt}     关键字: {dc.KeyWords}";
            Data = dc.Datas;
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
