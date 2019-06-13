using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using uStore.Data.EF;
using uStore.Domain.Repositories;

namespace uStoreProject.Controllers
{
    public class StatusController : Controller
    {
        StatusRepository repo = new StatusRepository();

        public ActionResult Index()
        {
            return View(repo.Get());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = repo.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusID, StatusName, StatusOrder, Notes")] Status status)
        {
            if (ModelState.IsValid)
            {
                repo.Add(status);
                return RedirectToAction("Index");
            }

            return View(status);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = repo.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusID, StatusName, StatusOrder, Notes")] Status status)
        {
            if (ModelState.IsValid)
            {
                repo.Update(status);
                return RedirectToAction("Index");
            }
            return View(status);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = repo.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Status status = repo.Find(id);
            repo.Remove(status);
            return RedirectToAction("Index");
        }
    }
}
