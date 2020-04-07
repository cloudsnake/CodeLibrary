using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CodeLibrary.Helper
{
    public static class EnumHelper
    {   /// <summary>
        /// 根据枚举的值获取枚举名称
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="value">枚举的值</param>
        /// <returns></returns>
        public static string GetEnumName<T>(this int value)
        {
            Type enumType = typeof(T);

            string[] fieldstrs = Enum.GetNames(enumType); //获取枚举字段数组
            foreach (var item in fieldstrs)
            {
                string description = string.Empty;
                var field = enumType.GetField(item);
                object[] arr = field.GetCustomAttributes(typeof(DescriptionAttribute), true); //获取属性字段数组
                if (arr != null && arr.Length > 0)
                {
                    description = ((DescriptionAttribute)arr[0]).Description;   //属性描述
                }
                else
                {
                    description = item;  //描述不存在取字段名称
                }

                var _v = (int) Enum.Parse(enumType, item);
                if (value == _v)
                {
                    return description;
                }
            }

            return "No";
        }

        /// <summary>
        /// 枚举转字典集合(Key是value,Value是description（如果不存在description 则是name）)
        /// </summary>
        /// <typeparam name="T">枚举类名称</typeparam>
        /// <param name="keyDefault">默认key值</param>
        /// <param name="valueDefault">默认value值</param>
        /// <returns>返回生成的字典集合</returns>
        public static Dictionary<string, int> EnumListDic<T>(string keyDefault, int valueDefault = 0)
        {
            Dictionary<string, int> dicEnum = new Dictionary<string, int>();
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                return dicEnum;
            }

            if (!string.IsNullOrEmpty(keyDefault)) //判断是否添加默认选项
            {
                dicEnum.Add(keyDefault, valueDefault);
            }

            string[] fieldstrs = Enum.GetNames(enumType); //获取枚举字段数组
            foreach (var item in fieldstrs)
            {
                string description = string.Empty;
                var field = enumType.GetField(item);
                object[] arr = field.GetCustomAttributes(typeof(DescriptionAttribute), true); //获取属性字段数组
                if (arr != null && arr.Length > 0)
                {
                    description = ((DescriptionAttribute)arr[0]).Description;   //属性描述
                }
                else
                {
                    description = item;  //描述不存在取字段名称
                }
                dicEnum.Add(description, (int)Enum.Parse(enumType, item));  //不用枚举的value值作为字典key值的原因从枚举例子能看出来，其实这边应该判断他的值不存在，默认取字段名称
            }
            return dicEnum;
        }

    }
}
