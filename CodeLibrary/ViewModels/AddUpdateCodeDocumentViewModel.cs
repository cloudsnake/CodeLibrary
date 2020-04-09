using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using CodeLibrary.Data.Service;
using CodeLibrary.Helper;
using CodeLibrary.Model;
using Prism.Regions;

namespace CodeLibrary.ViewModels
{
    public class AddUpdateCodeDocumentViewModel : BindableBase, INavigationAware
    {
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var obj = navigationContext.Parameters["Id"];
            var guid = obj.ToString();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public DelegateCommand SaveCommand { get; private set; }

        public AddUpdateCodeDocumentViewModel()
        {
            SaveCommand = new DelegateCommand(OnSave);
            _languages = EnumHelper.EnumListDic<ProgrammingLanguage>("");
            _programmingTypes = EnumHelper.EnumListDic<ProgrammingType>("");
        }

        private async void OnSave()
        {
            var cd = new CodeDocument();
            cd.Title = this._title;
            cd.CreatedUtc = DateTime.UtcNow;
            cd.Datas = this._datas;
            cd.Deleted = false;
            cd.KeyWords = this._keyWords;
            cd.LastUpdatedUtc = DateTime.UtcNow;
            cd.OtherTechniques = string.Empty;
            cd.ProgrammingLanguageId = this._programmingLanguageId;
            cd.ProgrammingTypeId = this._programmingTypeId;
            await CodeDocumentService.InsertCodeDocument(cd);

            this.Title = string.Empty;
            this.Datas = string.Empty;
            this.KeyWords = string.Empty;
        }

        private int _id;

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }


        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _datas;

        public string Datas
        {
            get { return _datas; }
            set { SetProperty(ref _datas, value); }
        }

        private string _keyWords;

        public string KeyWords
        {
            get { return _keyWords; }
            set { SetProperty(ref _keyWords, value); }
        }

        private int _programmingTypeId;

        public int ProgrammingTypeId
        {
            get { return _programmingTypeId; }
            set { SetProperty(ref _programmingTypeId, value); }
        }

        private int _programmingLanguageId;

        public int ProgrammingLanguageId
        {
            get { return _programmingLanguageId; }
            set { SetProperty(ref _programmingLanguageId, value); }
        }

        private Dictionary<string, int> _languages;

        public Dictionary<string, int> Languages
        {
            get { return _languages; }
            set { SetProperty(ref _languages, value); }
        }

        private Dictionary<string, int> _programmingTypes;

        public Dictionary<string, int> ProgrammingTypes
        {
            get { return _programmingTypes; }
            set { SetProperty(ref _programmingTypes, value); }
        }

    }
}
