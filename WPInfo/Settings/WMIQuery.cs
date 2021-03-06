﻿using System;
using System.Collections.Generic;

namespace Ventajou.WPInfo
{
    public class WMIQuery : ICloneable
    {
        public static class Defaults
        {
            public const string Name = "WMIQuery1";
            public const string Namespace = "root\\cimV2";
            public const string Query = "";
        }

        public string Name { get; set; }
        public string Namespace { get; set; }
        public string Query { get; set; }

        #region ICloneable Members

        /// <summary>
        /// Implement the ICloneable interface
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            WMIQuery clone = new WMIQuery();
            clone.Name = Name.Clone() as string;
            clone.Namespace = Namespace.Clone() as string;
            clone.Query = Query.Clone() as string;

            return clone;
        }

        #endregion
    }
}
