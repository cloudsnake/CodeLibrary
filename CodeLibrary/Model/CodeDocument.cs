using System;
using System.Collections.Generic;
using System.Text;
using FreeSql.DataAnnotations;

namespace CodeLibrary.Model
{
    public class CodeDocument
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        public string Title { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
        public ProgrammingType ProgrammingType { get; set; }
        public virtual ICollection<OtherTechniques> OtherTechniques { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime LastUpdatedUtc { get; set; }
        public string Datas { get; set; }
        public ICollection<KeyWord> KeyWords { get; set; }
    }
}
