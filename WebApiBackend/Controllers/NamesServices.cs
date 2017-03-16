using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBackend.Controllers
{
    public class NameService
    {
        private string _myName;

        public NameService ( string myName )
        {
            _myName = myName;
        }

        public string GetMyName ()
        {
            return string.Format("My name is: {0}", _myName);
        }
    }
}