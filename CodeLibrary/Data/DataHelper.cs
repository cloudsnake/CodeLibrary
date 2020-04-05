using System;
using System.Collections.Generic;
using System.Text;

namespace CodeLibrary.Data
{
    public class DataHelper
    {
        #region Field
        public static DataHelper Instance { get { return lazy.Value; } }

        private static readonly Lazy<DataHelper> lazy = new Lazy<DataHelper>(() => new DataHelper());
        private IFreeSql _freeSql;
        #endregion
        public IFreeSql Current
        {
            get => _freeSql;
        }
        private DataHelper()
        {

            var connstr = @"Data Source=|DataDirectory|\db1.db;Attachs=db2.db;Pooling=true;Max Pool Size=10";
            _freeSql = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.Sqlite, connstr)
                .UseAutoSyncStructure(true) //自动同步实体结构到数据库 
                .UseLazyLoading(true)
                .Build();
        }

    }
}
