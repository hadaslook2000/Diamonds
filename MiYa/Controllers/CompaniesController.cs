using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiYa.Models;

namespace MiYa.Controllers
{

    public class CompaniesController : Controller
    {
        public static Companies c1 = new Companies();

        private MiYaEntities db = new MiYaEntities();

        public static int id1 = -1;


        // GET: Companies
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult LogOn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOn(string UserName, string Password)
        {
            ViewBag.eror = "";
            try
            {
                Companies company = db.Companies.First(c => c.UserName == UserName && c.Password == Password);//לדאוג לכך שלא יהיו 2 חברות עם אותו שם וסיסמא
                if (UserName == "alorin@2018" && Password == "11050")
                    return RedirectToAction("Home1", "Orders", company);
                return RedirectToAction("Home", "Orders", company);
            }
            catch
            {
                ViewBag.eror = "user name or password are incorrect";
                return View();
            }

        }

        public ActionResult Index()
        {
            var companies = db.Companies.Include(c => c.Classifications).Include(c => c.Countries).Include(c => c.Prefixes);
            return View(companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companies companies = db.Companies.Find(id);
            if (companies == null)
            {
                return HttpNotFound();
            }
            return View(companies);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            ViewBag.Classification = new SelectList(db.Classifications, "ClassificationId", "Classification");
            ViewBag.Country = new SelectList(db.Countries, "CountryId", "Country");
            ViewBag.Prefix = new SelectList(db.Prefixes, "PrefixId", "Prefix");

            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyId,Company,Classification,ContactPerson,Prefix,Mobile,Phone,EMail,Address,Country,DateRegistration,UserName,Password")] Companies companies)
        {
            if (ModelState.IsValid)
            {
                companies.DateRegistration = DateTime.Now;
                db.Companies.Add(companies);
                db.SaveChanges();
                return RedirectToAction("Home", "Orders", companies);

            }

            ViewBag.Classification = new SelectList(db.Classifications, "ClassificationId", "Classification", companies.Classification);
            ViewBag.Country = new SelectList(db.Countries, "CountryId", "Country", companies.Country);
            ViewBag.Prefix = new SelectList(db.Prefixes, "PrefixId", "Prefix", companies.Prefix);
            return View(companies);
        }
        //בכדי שיוכלו לצפות בנתונים יש להחזיר ויו אינדקס
        //return RedirectToAction("Index");

        // GET: Companies/Edit/5
        public ActionResult Edit(int? idCompany)
        {
            if (idCompany == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companies companies = db.Companies.Find(idCompany);
            if (companies == null)
            {
                return HttpNotFound();
            }
            ViewBag.Classification = new SelectList(db.Classifications, "ClassificationId", "Classification", companies.Classification);
            ViewBag.Country = new SelectList(db.Countries, "CountryId", "Country", companies.Country);
            ViewBag.Prefix = new SelectList(db.Prefixes, "PrefixId", "Prefix", companies.Prefix);
            return View(companies);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyId,Company,Classification,ContactPerson,Prefix,Mobile,Phone,EMail,Address,Country,DateRegistration,UserName,Password,IsInterested")] Companies companies, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(collection["checkResp"]))
                {
                    string checkResp = collection["checkResp"];
                    bool checkRespB = Convert.ToBoolean(checkResp);
                    //companies.IsInterested =  checkRespB;
                }

                companies.DateRegistration = DateTime.Now;
                db.Entry(companies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Classification = new SelectList(db.Classifications, "ClassificationId", "Classification", companies.Classification);
            ViewBag.Country = new SelectList(db.Countries, "CountryId", "Country", companies.Country);
            ViewBag.Prefix = new SelectList(db.Prefixes, "PrefixId", "Prefix", companies.Prefix);
            return View(companies);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companies companies = db.Companies.Find(id);
            if (companies == null)
            {
                return HttpNotFound();
            }
            return View(companies);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Companies companies = db.Companies.Find(id);
            db.Companies.Remove(companies);
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
