using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApiBackend.Controllers
{
    public class NameController : ApiController
    {
        private NameService _nameService;

        public NameController ( NameService nameService )
        {
            _nameService = nameService;
        }

        public string Get ()
        {
            return _nameService.GetMyName();
        }
    }
}