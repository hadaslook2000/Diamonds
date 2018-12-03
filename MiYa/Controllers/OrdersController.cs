using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiYa.Models;
using MiYa.Controllers;

namespace MiYa.Controllers
{
    public class OrdersController : Controller
    {
        private MiYaEntities db = new MiYaEntities();
        //public int count = 0;
        // GET: Orders

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Home(Companies c)
        {
            MiYa.Controllers.CompaniesController.c1 = c;
            ViewBag.CompanyId = c.CompanyId;
            ViewBag.Company = c.Company;
            return View();
        }

        public ActionResult Home1(Companies c)
        {
            MiYa.Controllers.CompaniesController.c1 = c;
            ViewBag.CompanyId = c.CompanyId;
            ViewBag.Company = c.Company;
            return View();
        }
        //[HttpPost]
        //public ActionResult Home(FormCollection collection)
        //{
        //    only selected prodcuts will be in the collection
        //    return View();
        //}
        public ActionResult ConfirmYourPurchase()
        {
            List<Orders> rfqs = db.Orders.Where(r => r.CompanyId == MiYa.Controllers.CompaniesController.c1.CompanyId && r.Status == 3).ToList();
            ViewBag.Company = MiYa.Controllers.CompaniesController.c1.Company;
            ViewBag.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;
            return View(rfqs);
        }
        public ActionResult ApprovedPurchases()
        {
            List<Orders> rfqs = db.Orders.Where(r => r.CompanyId == MiYa.Controllers.CompaniesController.c1.CompanyId && r.Status == 4).ToList();
            ViewBag.Company = MiYa.Controllers.CompaniesController.c1.Company;
            ViewBag.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;
            return View(rfqs);
        }
        public ActionResult WaitingToYourApproval()
        {
            List<Orders> rfqs = db.Orders.Where(r => r.Status == 2).ToList();
            ViewBag.Company = MiYa.Controllers.CompaniesController.c1.Company;
            ViewBag.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;
            return View(rfqs);
        }
        public ActionResult WaitingForAdministrator()
        {
            List<Orders> rfqs = db.Orders.Where(r => r.CompanyId == MiYa.Controllers.CompaniesController.c1.CompanyId && r.Status == 2).ToList();
            ViewBag.Company = MiYa.Controllers.CompaniesController.c1.Company;
            ViewBag.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;
            return View(rfqs);
        }
        public ActionResult MyRfqDetails()
        {
            List<Orders> rfqs = db.Orders.Where(r => r.CompanyId == MiYa.Controllers.CompaniesController.c1.CompanyId && r.Status == 1).ToList();
            ViewBag.Company = MiYa.Controllers.CompaniesController.c1.Company;
            ViewBag.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;
            return PartialView(rfqs);
        }


        public ActionResult PasstoManager(int id, int quantity)
        {
            Orders o = new Orders();
            o = db.Orders.Find(id);
            o.Quantity = quantity;
            o.Status = 2;
            return View("Index");


        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyRfqDetails(int id, int qua) /*[Bind(Include = "OrderId,carat,Shape,Color,Clarity,Cut,Kind,RapScale_CtStone_Sizemm,Quantity,TotalCt,Status,DateOrder,Note")] Orders orders*/
        {
            Orders orders = new Orders();
            orders = db.Orders.Find(id);
            ViewBag.Company = MiYa.Controllers.CompaniesController.c1.Company;
            ViewBag.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;
            if (ModelState.IsValid)
            {
                //db.Entry(orders).State = EntityState.Modified;
                orders.Status = 2;
                orders.Quantity = qua;
                orders.DateOrder = DateTime.Now;
                db.Orders.Add(orders);
                db.SaveChanges();
                //RfqsOrders rfqs = new RfqsOrders();
                //rfqs.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;
                //rfqs.Status = 1;
                //rfqs.RfqId = RfqId;
                //rfqs.OrderId = orders.OrderId;
                //db.RfqsOrders.Add(rfqs);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Clarity = new SelectList(db.Clarities, "ClarityId", "Clarity", orders.Clarity);
            ViewBag.Color = new SelectList(db.Colors, "ColorId", "Color", orders.Color);
            ViewBag.Cut = new SelectList(db.Cuts, "CutId", "Cut", orders.Cut);
            ViewBag.Kind = new SelectList(db.Kinds, "KindId", "Kind", orders.Kind);
            ViewBag.RapScale_CtStone_Sizemm = new SelectList(db.RapScale_CtStone_Sizemms, "RapScale_CtStone_SizemmId", "RapScale_CtStone_Sizemm", orders.RapScale_CtStone_Sizemm);
            ViewBag.Shape = new SelectList(db.Shapes, "ShapeId", "Shape", orders.Shape);
            return View(orders);
        }
        public ActionResult Index()
        {
            ViewBag.Company = MiYa.Controllers.CompaniesController.c1.Company;
            ViewBag.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;
            return View();
        }
        public ActionResult Index1()
        {
            ViewBag.Company = MiYa.Controllers.CompaniesController.c1.Company;
            ViewBag.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;
            return View();
        }
        public ActionResult Details2(int? id)
        {
            //count++/*;*/
            //ViewBag.Company = MiYa.Controllers.CompaniesController.c1.Company;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            //if (MiYa.Controllers.CompaniesController.id1 == id)
            //{
            //    MiYa.Controllers.CompaniesController.id1 = -1;
            //    return View("Details3");
            //}
            //if(count==1)
            //{
            MiYa.Controllers.CompaniesController.id1 = Convert.ToInt32(id);
            //}
            return View(orders);

            //
        }
        public ActionResult Details3()
        {
            return View();
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Company = MiYa.Controllers.CompaniesController.c1.Company;
            ViewBag.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.Clarity = new SelectList(db.Clarities, "ClarityId", "Clarity");
            ViewBag.Color = new SelectList(db.Colors, "ColorId", "Color");
            ViewBag.Cut = new SelectList(db.Cuts, "CutId", "Cut");
            ViewBag.Kind = new SelectList(db.Kinds, "KindId", "Kind");
            ViewBag.RapScale_CtStone_Sizemm = new SelectList(db.RapScale_CtStone_Sizemms, "RapScale_CtStone_SizemmId", "RapScale_CtStone_Sizemm");
            ViewBag.Shape = new SelectList(db.Shapes, "ShapeId", "Shape");
            ViewBag.Company = MiYa.Controllers.CompaniesController.c1.Company;
            ViewBag.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;
            //ViewBag.ContactPerson = company.ContactPerson;
            //ViewBag.Adress = "rachli Kahanovitch";
            //ViewBag.hhh = company.Country;

            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,Shape,Color,Clarity,Cut,Kind,RapScale_CtStone_Sizemm,Carat,Quantity,TotalCt,Note")] Orders orders)
        {
            ViewBag.Companmgy = MiYa.Controllers.CompaniesController.c1.Company;
            ViewBag.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;

            if (ModelState.IsValid)
            {

                orders.CompanyId = ViewBag.CompanyId;
                orders.DateOrder = DateTime.Now;
                orders.Status = 1;
                db.Orders.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Clarity = new SelectList(db.Clarities, "ClarityId", "Clarity", orders.Clarity);
            ViewBag.Color = new SelectList(db.Colors, "ColorId", "Color", orders.Color);
            ViewBag.Cut = new SelectList(db.Cuts, "CutId", "Cut", orders.Cut);
            ViewBag.Kind = new SelectList(db.Kinds, "KindId", "Kind", orders.Kind);
            ViewBag.RapScale_CtStone_Sizemm = new SelectList(db.RapScale_CtStone_Sizemms, "RapScale_CtStone_SizemmId", "RapScale_CtStone_Sizemm", orders.RapScale_CtStone_Sizemm);
            ViewBag.Shape = new SelectList(db.Shapes, "ShapeId", "Shape", orders.Shape);
            return View(orders);
        }
        // GET: Orders/Edit/5
        public ActionResult Edit(int? id, int rfqId)
        {
            ViewBag.Company = MiYa.Controllers.CompaniesController.c1.Company;
            ViewBag.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.Clarity = new SelectList(db.Clarities, "ClarityId", "Clarity", orders.Clarity);
            ViewBag.Color = new SelectList(db.Colors, "ColorId", "Color", orders.Color);
            ViewBag.Cut = new SelectList(db.Cuts, "CutId", "Cut", orders.Cut);
            ViewBag.Kind = new SelectList(db.Kinds, "KindId", "Kind", orders.Kind);
            ViewBag.RapScale_CtStone_Sizemm = new SelectList(db.RapScale_CtStone_Sizemms, "RapScale_CtStone_SizemmId", "RapScale_CtStone_Sizemm", orders.RapScale_CtStone_Sizemm);
            ViewBag.Shape = new SelectList(db.Shapes, "ShapeId", "Shape", orders.Shape);
            ViewBag.RfqId = rfqId;
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,Shape,Color,Clarity,Cut,Kind,RapScale_CtStone_Sizemm,Quantity,TotalCt,Status,DateOrder,Note")] Orders orders, int RfqId)
        {
            ViewBag.Company = MiYa.Controllers.CompaniesController.c1.Company;
            ViewBag.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;

            if (ModelState.IsValid)
            {
                //db.Entry(orders).State = EntityState.Modified;
                orders.DateOrder = DateTime.Now;
                db.Orders.Add(orders);
                db.SaveChanges();
                //RfqsOrders rfqs = new RfqsOrders();
                //rfqs.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;
                //rfqs.Status = 1;
                //rfqs.RfqId = RfqId;
                //rfqs.OrderId = orders.OrderId;

                //db.RfqsOrders.Add(rfqs);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Clarity = new SelectList(db.Clarities, "ClarityId", "Clarity", orders.Clarity);
            ViewBag.Color = new SelectList(db.Colors, "ColorId", "Color", orders.Color);
            ViewBag.Cut = new SelectList(db.Cuts, "CutId", "Cut", orders.Cut);
            ViewBag.Kind = new SelectList(db.Kinds, "KindId", "Kind", orders.Kind);
            ViewBag.RapScale_CtStone_Sizemm = new SelectList(db.RapScale_CtStone_Sizemms, "RapScale_CtStone_SizemmId", "RapScale_CtStone_Sizemm", orders.RapScale_CtStone_Sizemm);
            ViewBag.Shape = new SelectList(db.Shapes, "ShapeId", "Shape", orders.Shape);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.Company = MiYa.Controllers.CompaniesController.c1.Company;
            ViewBag.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Company = MiYa.Controllers.CompaniesController.c1.Company;
            ViewBag.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;

            Orders orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            ViewBag.Company = MiYa.Controllers.CompaniesController.c1.Company;
            ViewBag.CompanyId = MiYa.Controllers.CompaniesController.c1.CompanyId;

            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
