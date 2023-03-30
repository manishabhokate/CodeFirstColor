using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using CodeFirstColor.Models;
using Newtonsoft.Json.Serialization;

namespace CodeFirstColor.Controllers
{
    public class TestController : Controller
    {
        Context cc = new Context();
        // GET: Test
        public ActionResult Index()
        {
            //var v = from t in cc.ProductColors
            //        join t1 in cc.Products
            //        on t.ProductId equals t1.ProductId
            //        group t by t1.ProductName into g
            //        select new VMColor
            //        { 
            //            ProductName = g.Key,
            //            ColorCount = g.Count()
            //        };

            var v = from t in  cc.Products
                    select new VMColor
                    { 
                        ProductId=t.ProductId,
                        ProductName = t.ProductName,
                        ColorCount = t.ProductColors.Count()
                    };

            return View(v.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product rec,Int64[] chk)
        {
            this.cc.Products.Add(rec);
            this.cc.SaveChanges();
            foreach(Int64 cid in chk)
            {
                ProductColor temp =new ProductColor();
                temp.ColorId=cid;
                temp.ProductId=rec.ProductId;
                this.cc.ProductColors.Add(temp);
            }
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
        [ChildActionOnly]
        public ActionResult GetCheckBox()
        {
            var v = from t in cc.Colors
                    select new CheckBoxVm    
                    {
                       Value=t.ColorId,
                       Text=t.ColorName,
                       IsSelected=false
                    };
            return View("_CheckBoxList", v.ToList());
        }
        [HttpGet]
        public ActionResult Edit(Int64 id)
        {
            var rec = this.cc.Products.Find(id);
            return View(rec);
        }
        [ChildActionOnly]
        public ActionResult GetChecked(Int64 id)
        {
            var rec=this.cc.Products.Find(id);
            var c=rec.ProductColors.Select(p=>p.ColorId).ToList();
            var v = from t in cc.Colors
                    select new CheckBoxVm
                    {
                        Value = t.ColorId,
                        Text = t.ColorName,
                        IsSelected =c.Contains(t.ColorId)
                    };
            ViewBag.Chk = v.ToList();
            return View("_CheckBoxList", v.ToList());
        }
        [HttpPost]
        public ActionResult Edit(Product rec, Int64[] chk)
        {
            this.cc.Entry(rec).State = System.Data.Entity.EntityState.Modified;
            this.cc.SaveChanges();
            var plr=this.cc.ProductColors.Where(p=>p.ProductId==rec.ProductId).ToList();
            foreach(var c in plr)
            {
                this.cc.ProductColors.Remove(c);
            }
            foreach(Int64 cid in chk)
            {
                ProductColor temp=new ProductColor();
                temp.ColorId = cid;
                temp.ProductId = rec.ProductId;
                this.cc.ProductColors.Add(temp);
            }
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
         public ActionResult Details(Int64 id)
        {
            var rec=this.cc.Products.Find(id);
            return View(rec);
        }

        [HttpGet]
        public ActionResult Delete(Int64 id)
        {
           
            var rec = this.cc.Products.Find(id);
            this.cc.Products.Remove(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}