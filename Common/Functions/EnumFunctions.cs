using System;
using System.ComponentModel;

namespace Common.Functions
{
    public static class EnumFunctions
    {
        //Enum ların description larının okunması için;
        private static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                var memberInfo = value.GetType().GetMember(value.ToString());
                var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
                return (T)attributes[0];
            }
        }

        public static string ToName(this Enum value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                var attribute = value.GetAttribute<DescriptionAttribute>();
                return attribute == null ? value.ToString() : attribute.Description;
            }
        }
    }
}
