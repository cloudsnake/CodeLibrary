using System;
using System.Collections.Generic;
using System.Text;

namespace CodeLibrary.Model
{
    public enum ProgrammingType
    {
        /// <summary>
        /// 未知
        /// </summary>
        No = 0x00,
        /// <summary>
        /// C
        /// </summary>
        C = 0x01,
        /// <summary>
        /// MFC
        /// </summary>
        Mfc = 0x02,
        /// <summary>
        /// Net Framework
        /// </summary>
        NetFramework = 0x03,
        /// <summary>
        /// Net Core
        /// </summary>
        NetCore = 0x04,
        /// <summary>
        /// WPF
        /// </summary>
        Wpf = 0x05,
        /// <summary>
        /// SpringMvc
        /// </summary>
        SpringMvc = 0x06,
        /// <summary>
        /// Hibernate
        /// </summary>
        Hibernate = 0x07,
        /// <summary>
        /// Struts2
        /// </summary>
        Struts2 = 0x08,
        /// <summary>
        /// Java
        /// </summary>
        Java = 0x09
    }
}
