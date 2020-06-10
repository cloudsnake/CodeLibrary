using System.ComponentModel;

namespace CodeLibrary.Model
{
    public enum ProgrammingType
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        No = 0x00,
        /// <summary>
        /// C
        /// </summary>
        [Description("C语言")]
        C = 0x01,
        /// <summary>
        /// MFC
        /// </summary>
        [Description("MFC")]
        Mfc = 0x02,
        /// <summary>
        /// Net Framework
        /// </summary>
        [Description("Net Framework")]
        NetFramework = 0x03,
        /// <summary>
        /// Net Core
        /// </summary>
        [Description("Net Core")]
        NetCore = 0x04,
        /// <summary>
        /// WPF
        /// </summary>
        [Description("WPF")]
        Wpf = 0x05,
        /// <summary>
        /// SpringMvc
        /// </summary>
        [Description("SpringMVC")]
        SpringMvc = 0x06,
        /// <summary>
        /// Hibernate
        /// </summary>
        [Description("Hibernate")]
        Hibernate = 0x07,
        /// <summary>
        /// Struts2
        /// </summary>
        [Description("Struts2")]
        Struts2 = 0x08,
        /// <summary>
        /// Java
        /// </summary>
        [Description("JAVA")]
        Java = 0x09
    }
}
