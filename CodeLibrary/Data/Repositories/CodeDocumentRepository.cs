using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using CodeLibrary.Model;
using FreeSql;

namespace CodeLibrary.Data.Repositories
{
    public class CodeDocumentRepository : BaseRepository<CodeDocument, int>
    {
        public CodeDocumentRepository(IFreeSql fsql) : base(fsql, null, null)
        {

            
        }
    }
}
