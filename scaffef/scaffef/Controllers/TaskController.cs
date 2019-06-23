using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using scaffef.Models;

namespace scaffef.Controllers
{
    public class TaskController : Controller
    {
        private ProjectTasksEntities db = new ProjectTasksEntities();

        // GET: /Task/
        public ActionResult Index()
        {
            var tbltasks = db.tblTasks.Include(t => t.tblPriority).Include(t => t.tblProject).Include(t => t.tblStatu).Include(t => t.tblSubCategory);
            return View(tbltasks.ToList());
        }

        // GET: /Task/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTask tbltask = db.tblTasks.Find(id);
            if (tbltask == null)
            {
                return HttpNotFound();
            }
            return View(tbltask);
        }

        // GET: /Task/Create
        public ActionResult Create()
        {
            ViewBag.PriorityID = new SelectList(db.tblPriorities, "PriorityID", "PriorityName");
            ViewBag.ProjectID = new SelectList(db.tblProjects, "ProjectID", "ProjectName");
            ViewBag.StatusID = new SelectList(db.tblStatus, "StatusID", "StatusName");
            ViewBag.SubCategoryID = new SelectList(db.tblSubCategories, "SubCategoryID", "SubCategoryName");
            return View();
        }

        // POST: /Task/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TaskID,ProjectID,Title,EndUser,AssignedTo,OpenedBy,OpenedDate,StatusID,SubCategoryID,PriorityID,Description,ScheduledStart,ActualStart,ScheduledFinish,EstFinish,ActualFinish,EstDurationDays,DateModified,RelatedIssues,Comments,Publicity,PctComplete,GroupName,IISR,Atch")] tblTask tbltask)
        {
            if (ModelState.IsValid)
            {
                db.tblTasks.Add(tbltask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PriorityID = new SelectList(db.tblPriorities, "PriorityID", "PriorityName", tbltask.PriorityID);
            ViewBag.ProjectID = new SelectList(db.tblProjects, "ProjectID", "ProjectName", tbltask.ProjectID);
            ViewBag.StatusID = new SelectList(db.tblStatus, "StatusID", "StatusName", tbltask.StatusID);
            ViewBag.SubCategoryID = new SelectList(db.tblSubCategories, "SubCategoryID", "SubCategoryName", tbltask.SubCategoryID);
            return View(tbltask);
        }

        // GET: /Task/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTask tbltask = db.tblTasks.Find(id);
            if (tbltask == null)
            {
                return HttpNotFound();
            }
            ViewBag.PriorityID = new SelectList(db.tblPriorities, "PriorityID", "PriorityName", tbltask.PriorityID);
            ViewBag.ProjectID = new SelectList(db.tblProjects, "ProjectID", "ProjectName", tbltask.ProjectID);
            ViewBag.StatusID = new SelectList(db.tblStatus, "StatusID", "StatusName", tbltask.StatusID);
            ViewBag.SubCategoryID = new SelectList(db.tblSubCategories, "SubCategoryID", "SubCategoryName", tbltask.SubCategoryID);
            return View(tbltask);
        }

        // POST: /Task/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TaskID,ProjectID,Title,EndUser,AssignedTo,OpenedBy,OpenedDate,StatusID,SubCategoryID,PriorityID,Description,ScheduledStart,ActualStart,ScheduledFinish,EstFinish,ActualFinish,EstDurationDays,DateModified,RelatedIssues,Comments,Publicity,PctComplete,GroupName,IISR,Atch")] tblTask tbltask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbltask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PriorityID = new SelectList(db.tblPriorities, "PriorityID", "PriorityName", tbltask.PriorityID);
            ViewBag.ProjectID = new SelectList(db.tblProjects, "ProjectID", "ProjectName", tbltask.ProjectID);
            ViewBag.StatusID = new SelectList(db.tblStatus, "StatusID", "StatusName", tbltask.StatusID);
            ViewBag.SubCategoryID = new SelectList(db.tblSubCategories, "SubCategoryID", "SubCategoryName", tbltask.SubCategoryID);
            return View(tbltask);
        }

        // GET: /Task/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTask tbltask = db.tblTasks.Find(id);
            if (tbltask == null)
            {
                return HttpNotFound();
            }
            return View(tbltask);
        }

        // POST: /Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTask tbltask = db.tblTasks.Find(id);
            db.tblTasks.Remove(tbltask);
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
