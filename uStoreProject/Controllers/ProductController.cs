using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using uStore.Data.EF;

namespace uStoreProject.Controllers
{
    public class ProductController : Controller
    {
        private uStoreEntities db = new uStoreEntities();

        // GET: Product
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Status);
            return View(products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.StatusID = new SelectList(db.Statuses, "StatusID", "StatusName");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,Description,Price,UnitsInStock,ProductImage,StatusID,CategoryID,Notes,ReferenceURL")] Product product, HttpPostedFileBase ProductImage)
        {
            if (ModelState.IsValid)
            {
                #region File Upload
                string img = "NoImage.jpg";
                if (ProductImage != null)
                {
                    img = ProductImage.FileName;

                    string ext = img.Substring(img.LastIndexOf("."));

                    string[] goodExts = new string[] { ".jpg", ".jpeg", ".gif", ".png" };

                    if (goodExts.Contains(ext.ToLower()))
                    {
                        img = Guid.NewGuid() + ext;

                        ProductImage.SaveAs(Server.MapPath("~/Content/img/" + img));
                    }
                    else
                    {
                        img = "NoImage.jpg";
                    }
                }

                product.ProductImage = img;
                #endregion
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.StatusID = new SelectList(db.Statuses, "StatusID", "StatusName", product.StatusID);
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.StatusID = new SelectList(db.Statuses, "StatusID", "StatusName", product.StatusID);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,Description,Price,UnitsInStock,ProductImage,StatusID,CategoryID,Notes,ReferenceURL")] Product product, HttpPostedFileBase ProductImage)
        {
            if (ModelState.IsValid)
            {
                #region File Upload
                if (ProductImage != null)
                {
                    string img = ProductImage.FileName;

                    string ext = img.Substring(img.LastIndexOf("."));

                    string[] goodExts = new string[] { ".jpg", ".jpeg", ".gif", ".png" };

                    if (goodExts.Contains(ext.ToLower()))
                    {
                        img = Guid.NewGuid() + ext;

                        ProductImage.SaveAs(Server.MapPath("~/Content/img/" + img));

                        product.ProductImage = img;
                        if (Session["currentImage"].ToString() != "NoImage.jpg")
                        {
                            System.IO.File.Delete(Server.MapPath("~/Content/img/"
                                + Session["currentImage"].ToString()));

                            //if you had a thumbnail, you would want to delete it as well.
                            //System.IO.File.Delete(Server.MapPath("~/Content/img/t_"
                            //    + Session["currentImage"].ToString()));
                        }
                    }
                }

                #endregion

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.StatusID = new SelectList(db.Statuses, "StatusID", "StatusName", product.StatusID);
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);

            if (Session["currentImage"].ToString() != "NoImage.jpg")
            {
                System.IO.File.Delete(Server.MapPath("~/Content/img/" + product.ProductImage));
            }

            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
