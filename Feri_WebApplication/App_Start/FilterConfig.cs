using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feri_WebApplication.App_Start
{
    public static class FilterConfig
    {
        static FilterConfig()
        {

        }

        public static void RegisterGlobalFilter(System.Web.Mvc.GlobalFilterCollection filters)
        {
            filters.Add(new Infrastructor.LogAttribute());

        }//hello
        
    }
}