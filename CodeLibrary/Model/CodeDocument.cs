using FreeSql.DataAnnotations;
using System;

namespace CodeLibrary.Model
{
    public class CodeDocument
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public int ProgrammingTypeId { get; set; }
        public string OtherTechniques { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime LastUpdatedUtc { get; set; }
        public string Datas { get; set; }
        public string KeyWords { get; set; }
        public bool Deleted { get; set; }
    }
}
