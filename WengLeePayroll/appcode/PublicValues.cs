using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WengLeePayroll.appcode
{
    public static class PublicValues
    {
        /// <summary>
        /// Global variable that is constant.
        /// </summary>
        public const string PublicString = "Constant";

        
        static int _PublicValue;
        public static int PublicValue
        {
            get
            {
                return _PublicValue;
            }
            set
            {
                _PublicValue = value;
            }
        }

        static int _UserId;
        public static int UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }

        static string _UserName;
        public static string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }
        static string _Password;
        public static string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
        static int _UserLevel;
        public static int UserLevel
        {
            get
            {
                return _UserLevel;
            }
            set
            {
                _UserLevel = value;
            }
        }
        /// <summary>
        /// Global static field.
        /// </summary>
        public static bool PublicBoolean;
    }
}
