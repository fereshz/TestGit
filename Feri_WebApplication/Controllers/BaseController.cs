using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feri_WebApplication.Controllers
{
    public partial class BaseController : Controller
    {
        // GET: Base

        private Models.DatabaseContext databaseContext;

        protected Models.DatabaseContext DatabaseContext
        {
            get
            {
                if (databaseContext == null)
                {
                    databaseContext = new Models.DatabaseContext();
                }

                return (databaseContext);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (databaseContext != null)
                {
                    databaseContext.Dispose();
                    databaseContext = null;
                }

            }
            base.Dispose(disposing);
        }
    }
}