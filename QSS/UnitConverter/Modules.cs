using System;
using System.Collections.Generic;
using System.Text;

namespace QsScriptExtentions.UnitConverter
{
    public static class Modules
    {
        private static string CheckExists(string className)
        {
            System.Type type = System.Type.GetType(className);
            if (type != null)
                return "1";
            return "0";
        }

        //public static int GetType(string key)
        //{
        //    for (int x = 0; x < UnitTypes.Length; x++)
        //    {
        //        if (UnitTypes[x, 0] == key) { return x; }
        //    }
        //    return -1;
        //}

        //private static System.Type Exists(int index)
        //{
        //    return System.Type.GetType("uuc." + UnitTypes[index, 2].ToString());
        //}

        //private static System.Type Exists(int index)
        //{
        //    return System.Type.GetType("uuc." + UnitTypes[index, 2].ToString());
        //}
    }
}
