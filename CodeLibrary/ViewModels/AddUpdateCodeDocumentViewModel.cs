using CodeLibrary.Data.Service;
using CodeLibrary.Helper;
using CodeLibrary.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using ICSharpCode.AvalonEdit.Document;

namespace CodeLibrary.ViewModels
{
    public class AddUpdateCodeDocumentViewModel : BindableBase, INavigationAware
    {
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var obj = navigationContext.Parameters["Id"];
            if (obj == null)
            {
                return;
            }
            var sid = obj.ToString();
            if (!int.TryParse(sid, out UpdateDocumentId))
            {
                return;
            }

            if (UpdateDocumentId <= 0)
            {
                return;
            }
            GetCodeDocumentById(UpdateDocumentId);
        }

        private CodeDocument updateDocument = null;
        private int UpdateDocumentId = 0;
        private async void GetCodeDocumentById(int id)
        {
            var currentCodeDocument = await CodeDocumentService.GetCodeDocumentById(id);
            if (currentCodeDocument != null)
            {
                updateDocument = currentCodeDocument;
                Title = currentCodeDocument.Title;
                //Data = currentCodeDocument.Datas;
                Document = new TextDocument(new StringTextSource(currentCodeDocument.Datas));
                ProgrammingLanguageId = currentCodeDocument.ProgrammingLanguageId;
                ProgrammingTypeId = currentCodeDocument.ProgrammingTypeId;
                KeyWords = currentCodeDocument.KeyWords;
                UpdateDocumentId = currentCodeDocument.Id;

            }
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public DelegateCommand SaveCommand { get; private set; }

        public DelegateCommand CleanCommand { get; private set; }

        public AddUpdateCodeDocumentViewModel()
        {
            SaveCommand = new DelegateCommand(OnSave);
            CleanCommand = new DelegateCommand(OnClean);

            _languages = EnumHelper.EnumListDic<ProgrammingLanguage>("");
            _programmingTypes = EnumHelper.EnumListDic<ProgrammingType>("");
            Document = new TextDocument(new StringTextSource(""));
        }

        private void OnClean()
        {
            Document = new TextDocument(new StringTextSource(""));
        }
        private async void OnSave()
        {

            var cd = new CodeDocument();
            if (UpdateDocumentId > 0)
            {
                cd.Id = UpdateDocumentId;
            }
            cd.Title = this._title;
            cd.Datas = this._document.Text;
            cd.Deleted = false;
            cd.KeyWords = this._keyWords;
            if (UpdateDocumentId <= 0)
            {
                cd.CreatedUtc = DateTime.UtcNow;
            }
            cd.LastUpdatedUtc = DateTime.UtcNow;
            cd.OtherTechniques = string.Empty;
            cd.ProgrammingLanguageId = this._programmingLanguageId;
            cd.ProgrammingTypeId = this._programmingTypeId;
            if (UpdateDocumentId <= 0)
            {
                await CodeDocumentService.InsertCodeDocument(cd);
            }
            else
            {
                await CodeDocumentService.UpdateCodeDocument(cd);
                UpdateDocumentId = 0;
            }

            this.Title = string.Empty;
            this.Document = new TextDocument(new StringTextSource(""));
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


        private TextDocument _document;

        public TextDocument Document
        {
            get { return _document; }
            set { SetProperty(ref _document, value); }
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
