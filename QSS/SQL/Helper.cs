using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using QsScriptExtentions.Arrays;
using QsScriptExtentions.Attributes;

namespace QsScriptExtentions.SQL
{
    /// <summary>
    /// This class contains some usefull stuff for sql quarrys 
    /// </summary>
    public static class Helper
    {

        /// <summary>
        /// Converts PropertyInfo array to a sql select quarry
        /// </summary>
        /// <param name="props"></param>
        /// <param name="excludeStrings"></param>
        /// <returns></returns>
        public static string SelectFormatPropertysInfo(this PropertyInfo[] props, string[] excludeStrings = null)
        {
            if (props == null)
                return "";
            if (props.Length == 0)
                return "";

            string returnValue = "";
            for (int i = 0; i < props.Length; i++)
            {
                if (excludeStrings != null && excludeStrings.Contains(props[i].Name))
                    continue;
                if (Attribute.IsDefined(props[i], typeof(DatabaseIgnore)))
                    continue;
                returnValue += $"{props[i].Name}, ";
            }

            if (returnValue.Substring(returnValue.Length - 2, 2) == ", ")
                returnValue = returnValue.Substring(0, returnValue.Length - 2);

            return returnValue;
        }


        /// <summary>
        /// Converts PropertyInfo array to a sql where quarry
        /// </summary>
        /// <param name="props"></param>
        /// <param name="wheres"></param>
        /// <param name="expectedValue"></param>
        /// <returns></returns>
        public static string WhereFormatPropertysInfo(this PropertyInfo[] props, string[] wheres = null, string[] expectedValue = null)
        {
            if (props.ContainsArray(wheres).Contains(false))
                return "";
            string returnValue = "";

            if (wheres == null)
                return "";
            if (wheres.Length == 0)
                return "";
            if (wheres.Length == 1)
            {
                if (expectedValue == null)
                    return "";
                else if (expectedValue.Length == 0)
                    return "";
                else if (expectedValue.Length != wheres.Length)
                    return "";
                return $"where {wheres[0]}={expectedValue[0]}";
            }

            returnValue += "where ";
            for (int i = 0; i < props.Length; i++)
            {
                returnValue += $"{wheres[i]}={expectedValue[i]} AND ";
            }

            if (returnValue.Substring(returnValue.Length - 5, 5) == " AND ")
                returnValue = returnValue.Substring(0, returnValue.Length - 5);
            return returnValue;
        }
    }
}
