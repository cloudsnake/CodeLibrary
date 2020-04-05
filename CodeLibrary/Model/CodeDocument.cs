using System;
using System.Collections.Generic;
using System.Text;

namespace CodeLibrary.Model
{
    public class CodeDocument
    {
        public string Title { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
        public ProgrammingType ProgrammingType { get; set; }
        public virtual ICollection<OtherTechniques> OtherTechniques { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime LastUpdatedUtc { get; set; }
        public ICollection<byte> Datas { get; set; }
        public ICollection<KeyWord> KeyWords { get; set; }
    }
}
