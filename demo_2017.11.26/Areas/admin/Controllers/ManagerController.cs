using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using demo_2017._11._26.Attributes;
using demo_2017._11._26.Models;

namespace demo_2017._11._26.Areas.admin.Controllers
{
    public class ManagerController : Controller
    {
        private articleContext db = new articleContext();


        // GET: admin/Manager
        [MyAuthorize]
        public ActionResult Index()
        {
            return View(db.articles.ToList());
        }

        // GET: admin/Manager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            article article = db.articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: admin/Manager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Manager/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,artDate,title,content")] article article)
        {
            if (ModelState.IsValid)
            {
                db.articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: admin/Manager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            article article = db.articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: admin/Manager/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,artDate,title,content")] article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: admin/Manager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            article article = db.articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: admin/Manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            article article = db.articles.Find(id);
            db.articles.Remove(article);
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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(vwLoginUser model)
        {
            if (model.code == "admin" && model.pwd == "1234")
            {
                Session["auth"] = true;
                Session["usr"] = model.code;
                //return RedirectToAction("Index", "Home");
                
                return RedirectToAction("Index", "Manager");
            }
            else
            {
                ModelState.AddModelError("", "帳號密碼錯誤");
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["auth"] = false;
            return RedirectToAction("Index", "Manager");
        }

        public JsonResult test()
        {
            List<article> list = new List<article>();
            article customerA;

            customerA = new article();
            customerA.artDate = "2017/11/27";
            customerA.title = "XXX";
            customerA.content = "1234";
            list.Add(customerA);

            var Result = new
            {
                data = list
            };

            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            return View();
        }
        
        public ActionResult Home()
        {
            return View(db.articles.ToList());
        }

        public ActionResult NewPage()
        {

            return View(db.articles.ToList());
        }
    }
}
