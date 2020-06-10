using System.ComponentModel;

namespace CodeLibrary.Model
{
    public enum ProgrammingLanguage
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
        /// C#
        /// </summary>
        [Description("C#")]
        CSharp = 0x02,
        /// <summary>
        /// C++
        /// </summary>
        [Description("C++")]
        CPlusPlus = 0x3,
        /// <summary>
        /// JavaScript
        /// </summary>
        [Description("JavaScript")]
        JavaScript = 0x04,
        /// <summary>
        /// Html
        /// </summary>
        [Description("Html")]
        Html = 0x05,
        /// <summary>
        /// TypeScript
        /// </summary>
        [Description("TypeScript")]
        TypeScript = 0x06,
        /// <summary>
        /// CSS
        /// </summary>
        [Description("CSS")]
        Css = 0x07,
        /// <summary>
        /// Dockerfile
        /// </summary>
        [Description("Dockerfile")]
        Dockerfile = 0x08,
        /// <summary>
        /// Shell
        /// </summary>
        [Description("Shell")]
        Shell = 0x09,
        /// <summary>
        /// PowerShell
        /// </summary>
        [Description("PowerShell")]
        PowerShell = 0x0a,
        /// <summary>
        /// F#
        /// </summary>
        [Description("F#")]
        FSharp = 0x0b,
        /// <summary>
        /// Vue
        /// </summary>
        [Description("Vue")]
        Vue = 0x0c,
        /// <summary>
        /// VisualBasic
        /// </summary>
        [Description("Visual Basic")]
        VisualBasic = 0x0d,
        /// <summary>
        /// Python
        /// </summary>
        [Description("Python")]
        Python = 0x0e,
        /// <summary>
        /// Java
        /// </summary>
        [Description("JAVA")]
        Java = 0x0f,
        /// <summary>
        /// PHP
        /// </summary>
        [Description("PHP")]
        Php = 0x11,
        /// <summary>
        /// SQL
        /// </summary>
        [Description("SQL")]
        Sql = 0x12,


    }
}
