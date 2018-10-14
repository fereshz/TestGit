using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Feri_WebApplication.Controllers
{
    public partial class PeopleController : BaseController
    {
        // GET: People
        public virtual ActionResult Index()
        {
            var people =
                DatabaseContext.People.Include(current => current.Role).ToList();
            //var people = db.People.Include(p => p.Role);
            return View(model: people);
        }

        // GET: People/Details/5
        public virtual ActionResult Details(Guid? id)
        {
            if (id.HasValue == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person =
                DatabaseContext.People
                .Where(current => current.Id == id)
                .FirstOrDefault();

            if (person == null)
            {
                return HttpNotFound();
            }

            return View(model: person);
        }

        // GET: People/Create
        public virtual ActionResult Create()
        {
            Person person = new Person();
            person.IsActive = true;

            var roles =
                DatabaseContext.Roles
                .Where(current => current.IsActive)
                .ToList();

            ViewBag.RoleId =
                new SelectList(items: roles, dataValueField: "id", dataTextField: "Name", selectedValue: null);

            return View(model: person);
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create([Bind(Exclude = "Id")] Person person)
        {
            Person foundedItem =
                DatabaseContext.People
                .Where(current => string.Compare(current.Name, person.Name, true) == 0).FirstOrDefault();

            if (foundedItem != null)
            {
                ModelState.AddModelError(key: "Name", errorMessage: "This is exists!");
            }

            if (ModelState.IsValid)
            {
                DatabaseContext.People.Add(person);
                DatabaseContext.SaveChanges();
                return RedirectToAction(MVC.People.Index());
            }

            var roles =
                DatabaseContext.Roles.Where(current => current.IsActive).ToList();

            ViewBag.RoleId = new SelectList(items: roles, dataValueField: "Id", dataTextField: "Name", selectedValue: person.RoleId);
            return View(person);
        }

        // GET: People/Edit/5
        public virtual ActionResult Edit(Guid? id)
        {
            if (id.HasValue == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person =
                DatabaseContext.People.Where(current => current.Id == id).FirstOrDefault();

            if (person == null)
            {
                return HttpNotFound();
            }

            var roles =
                DatabaseContext.Roles.Where(current => current.IsActive).ToList();

            ViewBag.RoleId = new SelectList(items: roles, dataValueField: "Id", dataTextField: "Name", selectedValue: person.RoleId);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(Person person)
        {
            Person originalItem =
                DatabaseContext.People.Where(current => current.Id == person.Id).FirstOrDefault();

            if (originalItem == null)
            {
                return HttpNotFound();
            }

            Person foundedItem =
                DatabaseContext.People
                .Where(current => current.Id != person.Id)
                .Where(current => string.Compare(current.Name, person.Name, true) == 0)
                .FirstOrDefault();

            if (foundedItem != null)
            {
                ModelState.AddModelError(key: "Name", errorMessage: "This is exists");
            }

            if (ModelState.IsValid)
            {
                originalItem.Name = person.Name;
                originalItem.Age = person.Age;
                originalItem.IsActive = person.IsActive;
                originalItem.Role = person.Role;

                DatabaseContext.SaveChanges();
                return RedirectToAction("Index");
            }

            var roles =
                DatabaseContext.Roles
                .Where(current => current.IsActive)
                .ToList();

            ViewBag.RoleId = new SelectList(items: roles, dataValueField: "Id", dataTextField: "Name", selectedValue: person.RoleId);
            return View(person);
        }

        // GET: People/Delete/5
        public virtual ActionResult Delete(Guid? id)
        {
            if (id.HasValue == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person =
                DatabaseContext.People
                .Where(current => current.Id == id)
                .FirstOrDefault();

            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(Guid id)
        {
            Person person =
                 DatabaseContext.People
                 .Where(current => current.Id == id)
                 .FirstOrDefault();

            if (person == null)
            {
                return HttpNotFound();
            }

            DatabaseContext.People.Remove(person);
            DatabaseContext.SaveChanges();
            return RedirectToAction(MVC.People.Index());
        }

    }
}
