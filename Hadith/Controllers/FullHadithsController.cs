using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hadith.Models;

namespace Hadith.Controllers
{
    public class FullHadithsController : Controller
    {
        private Bukhari_DataSQLEntities db = new Bukhari_DataSQLEntities();
        private NarratorsHadithViewModel narratorsHadith = new NarratorsHadithViewModel();
        // GET: FullHadiths
        public ActionResult Index()
        {
            ViewBag.NarratorName = new SelectList(db.Narrators.Take(10), "NarratorID", "NarratorNameWithArab");
            narratorsHadith.Hadiths = db.FullHadiths.Take(100).ToList();
            narratorsHadith.NarratorsList = new SelectList(db.Narrators.Take(1000).ToList(),"NarratorID", "NarratorNameWithArab");
            return View(narratorsHadith);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(NarratorsHadithViewModel narrator, FormCollection form)
        {
            string strDDLValue = form["NarratorID"].ToString();

            ViewBag.NarratorName = new SelectList(db.Narrators.Take(10), "NarratorID", "NarratorNameWithArab");
            narratorsHadith.Hadiths = db.FullHadiths.Take(100).ToList();
            foreach (string id in GenerateNarratorArray(strDDLValue))
            {
                narratorsHadith.Hadiths = narratorsHadith.Hadiths.Where(hadith => hadith.NarratorID.Contains(id)).ToList();
            }
            
            return View(narratorsHadith);
        }


        // GET: FullHadiths/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullHadith fullHadith = db.FullHadiths.Find(id);
            if (fullHadith == null)
            {
                return HttpNotFound();
            }
            return View(fullHadith);
        }

        // GET: FullHadiths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FullHadiths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HadithID,HadithWithArab,HaddithWithoutArab,NarratorsWithArab,NarratorsWithoutArab,HID,CID,BID,NarratorID,InHID,upsize_ts")] FullHadith fullHadith)
        {
            if (ModelState.IsValid)
            {
                db.FullHadiths.Add(fullHadith);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fullHadith);
        }

        // GET: FullHadiths/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullHadith fullHadith = db.FullHadiths.Find(id);
            if (fullHadith == null)
            {
                return HttpNotFound();
            }
            return View(fullHadith);
        }

        // POST: FullHadiths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HadithID,HadithWithArab,HaddithWithoutArab,NarratorsWithArab,NarratorsWithoutArab,HID,CID,BID,NarratorID,InHID,upsize_ts")] FullHadith fullHadith)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fullHadith).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fullHadith);
        }

        // GET: FullHadiths/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullHadith fullHadith = db.FullHadiths.Find(id);
            if (fullHadith == null)
            {
                return HttpNotFound();
            }
            return View(fullHadith);
        }

        // POST: FullHadiths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FullHadith fullHadith = db.FullHadiths.Find(id);
            db.FullHadiths.Remove(fullHadith);
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

        //Generating Narrator ids wrt database
        private string[] GenerateNarratorArray(string ids)
        {
            var ids_array = ids.Split(',');
            var database_narrators = ids_array.Select(x => "-" + x + "-").ToArray<string>();
            
            return database_narrators;
        }
    }
}
