using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infrastructor
{
    public class LogAttribute:System.Web.Mvc.ActionFilterAttribute
    {
        public LogAttribute()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            string actionName =
                filterContext.ActionDescriptor.ActionName;

            string controllerName =
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            string areaName = null;

            if (filterContext.RouteData.DataTokens["area"]!=null)
            {
                areaName =
                    filterContext.RouteData.DataTokens["area"].ToString();
            }

            System.Guid id = System.Guid.NewGuid();

            filterContext.HttpContext.Items["Uniq-Key"] = id;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            System.Guid id =
                (System.Guid) filterContext.HttpContext.Items["Uniq-Key"];
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}