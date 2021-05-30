using System;
using System.Collections.Generic;
using System.Text;

namespace QsScriptExtentions.Attributes
{
    public class StringValueAttribute : Attribute
    {
        #region Properties
        public string StringValue { get; protected set; }
        #endregion

        #region Constructor
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }
        #endregion
    }
}
