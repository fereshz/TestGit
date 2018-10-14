using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Models;

namespace Feri_WebApplication.Controllers
{
    public partial class RolesController : BaseController
    {
        public RolesController() : base()
        {

        }

        //private DatabaseContext DatabaseContext = new DatabaseContext();

        // GET: Roles

        [HttpGet]
        public virtual ViewResult Index()
        {
            var items =
                DatabaseContext.Roles.
                OrderBy(current => current.Name)
                .ToList()
                ;

            return (View(model: items));
        }

        // GET: Roles/Details/5
        [HttpGet]
        public virtual ActionResult Details(Guid? id)
        {
            if (id.HasValue == false)
            {
                return (new HttpStatusCodeResult(HttpStatusCode.BadRequest));
            }

            var FoundedeItem =
               DatabaseContext.Roles
               .Where(current => current.Id == id.Value)
               .FirstOrDefault();

            if (FoundedeItem == null)
            {
                return (HttpNotFound());
            }

            return (View(model: FoundedeItem));
        }

        // GET: Roles/Create
        [HttpGet]
        public virtual ActionResult Create()
        {
            Models.Role DefaultRole = new Models.Role();

            DefaultRole.IsActive = true;

            return View(model: DefaultRole);
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create([Bind(Exclude = "Id")] Models.Role role)
        {
            var FoundedItem =
               DatabaseContext.Roles
              .Where(current => string.Compare
               (current.Name, role.Name, true) == 0)
               .FirstOrDefault();

            if (FoundedItem != null)
            {
                ModelState.AddModelError(key: "Name", errorMessage: "This Is Exist, Choose Another One!");
            }

            if (ModelState.IsValid)
            {
                DatabaseContext.Roles.Add(role);
                DatabaseContext.SaveChanges();
                return RedirectToAction(MVC.Roles.Index());
            }

            return View(model: role);
        }

        [HttpGet]
        // GET: Roles/Edit/5
        public virtual ActionResult Edit(Guid? id)
        {
            if (id.HasValue == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var FoundedeItem =
               DatabaseContext.Roles
               .Where(current => current.Id == id.Value)
               .FirstOrDefault();

            if (FoundedeItem == null)
            {
                return (HttpNotFound());
            }

            return View(model: FoundedeItem);
        }


        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(Models.Role role)
        {
            Models.Role originalItem =
                DatabaseContext.Roles.Find(role.Id);

            if (originalItem == null)
            {
                return (HttpNotFound());
            }

            var foundedItem =
                DatabaseContext.Roles
                .Where(current => current.Id != role.Id)
                .Where(current => string.Compare
                (current.Name, role.Name, true) == 0)
                .FirstOrDefault();

            if (foundedItem != null)
            {
                ModelState.AddModelError(key: "Name", errorMessage: "This Is Exist, Choose Another One!");
            }

            if (ModelState.IsValid)
            {
                originalItem.Name = role.Name;
                originalItem.IsActive = role.IsActive;

                DatabaseContext.SaveChanges();

                return (RedirectToAction(MVC.Roles.Index()));
            }

            return (View(model: role));
        }

        // GET: Roles/Delete/5
        public virtual ActionResult Delete(Guid? id)
        {
            if (id.HasValue == false)
            {
                return (new HttpStatusCodeResult(HttpStatusCode.BadRequest));
            }

            var FoundedeItem =
               DatabaseContext.Roles
               .Where(current => current.Id == id.Value)
               .FirstOrDefault();

            if (FoundedeItem == null)
            {
                return (HttpNotFound());
            }

            return View(FoundedeItem);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(Guid? id)
        {
            var FoundedItem =
                DatabaseContext.Roles
                .Where(current => current.Id == id.Value)
                .FirstOrDefault();

            if (FoundedItem == null)
            {
                return (HttpNotFound());
            }

            DatabaseContext.Roles.Remove(FoundedItem);

            DatabaseContext.SaveChanges();

            return RedirectToAction(MVC.Roles.Index());
        }
    }
}
