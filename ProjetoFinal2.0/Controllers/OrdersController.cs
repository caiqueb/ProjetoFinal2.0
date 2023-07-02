﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal2._0.Classes;
using ProjetoFinal2._0.Models;

namespace ProjetoFinal2._0.Controllers
{
    public class OrdersController : Controller
    {
        private ProjetoContext db = new ProjetoContext();


        public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var orderDetailTmps = db.OrderDetailTmp.Where(odt => odt.UserName == User.Identity.Name && odt.ProductId == id).FirstOrDefault();

            if (orderDetailTmps == null)
            {
                return HttpNotFound();
            }
            db.OrderDetailTmp.Remove(orderDetailTmps);
            db.SaveChanges();
            return RedirectToAction("Create");
        }


        //ADD PRODUTOS GET
        public ActionResult AddProduct()
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(user.CompanyId, true), "ProductId", "Description");
            return PartialView();
        }



        //ADD PRODUTOS POST
        [HttpPost]
        public ActionResult AddProduct(AddProductView view)
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();

            if (ModelState.IsValid)
            {
                var orderDetailTmps = db.OrderDetailTmp.Where(odt => odt.UserName == User.Identity.Name && odt.ProductId == view.ProductId).FirstOrDefault();
                if (orderDetailTmps == null)
                {

                    var product = db.Products.Find(view.ProductId);
                    orderDetailTmps = new OrderDetailTmp
                    {
                        Description = product.Description,
                        Price = product.Price,
                        ProductId = product.ProductId,
                        Quantity = view.Quantity,
                        TaxRate = product.Tax.Rate,
                        UserName = User.Identity.Name,

                    };

                    db.OrderDetailTmp.Add(orderDetailTmps);

                }
                else
                {
                    orderDetailTmps.Quantity += view.Quantity;
                    db.Entry(orderDetailTmps).State = EntityState.Modified;

                }
                db.SaveChanges();
                return RedirectToAction("Create");

            }

            ViewBag.ProdutoId = new SelectList(CombosHelper.GetProducts(user.CompanyId), "ProductId", "Description");
            return PartialView();
        }





        // GET: Orders
        public ActionResult Index()
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            var orders = db.Orders.Where(c => c.CompanyId == user.CompanyId).Include(o => o.Customer).Include(o => o.State);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
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
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomer(user.CompanyId), "CustomerId", "FullName");
            var view = new NewOrderView
            {
                Date = DateTime.Now,
                Details = db.OrderDetailTmp.Where(odt => odt.UserName == User.Identity.Name).ToList(),
            };

            return View(view);
        }

        // POST: Orders/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewOrderView view)
        {
            if (ModelState.IsValid)
            {
                var response = MovementsHelper.NewOrder(view, User.Identity.Name);
                if (response.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, response.Message);

            }


            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomer(user.CompanyId), "CustomerId", "FullName", view.CustomerId);
            view.Details = db.OrderDetailTmp.Where(odt => odt.UserName == User.Identity.Name).ToList();
            return View(view);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomer(user.CompanyId), "CustomerId", "FullName", orders.CustomerId);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                var responseSaveImg = DBHelper.SaveChanges(db);
                if (responseSaveImg.Succeeded)
                {

                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, responseSaveImg.Message);

            }
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomer(user.CompanyId), "CustomerId", "FullName", orders.CustomerId);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
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
            Orders orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
            var responseSaveImg = DBHelper.SaveChanges(db);
            if (responseSaveImg.Succeeded)
            {

                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, responseSaveImg.Message);
            return View(orders);
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
