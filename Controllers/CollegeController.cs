using DemoADOMVC.Models;
using DemoADOMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoADOMVC.Controllers
{
    public class CollegeController : Controller
    {
        // GET: College/GetAllCollegeDetails
        public ActionResult GetAllCollegeDetails()
        {
            CollegeRepository ColRep = new CollegeRepository();
            ModelState.Clear();
            return View(ColRep.GetAllCollege());
        }

        // GET: College/AddCollege
        public ActionResult AddCollege()
        {
            return View();
        }

        // POST: College/AddCollege
        [HttpPost]
        public ActionResult AddCollege(Registration obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CollegeRepository ColReg=new CollegeRepository();
                    if (ColReg.AddCollege(obj))
                    {
                        ViewBag.Message = "College Details add successfully.";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }

        }

        // GET: College/EditCollegeDetails 
        [HttpGet]
        public ActionResult EditCollegeDetails(int id)
        {
            CollegeRepository ColRep = new CollegeRepository();
            return View(ColRep.GetAllCollege().Find(c => c.id == id));
        }
        // POST: College/EditCollegeDetails 
        [HttpPost]
        public ActionResult EditCollegeDetails(int id, Registration obj)
        {
            try
            {
                CollegeRepository ColRep=new CollegeRepository();
                ColRep.UpdateCollege(obj);
                return RedirectToAction("GetAllCollegeDetails");
            }
            catch
            {
                return View();
            }
            
        }

        // GET: College/DeleteCollege   
        public ActionResult Delete(int id)
        {
            try
            {
                CollegeRepository ColRep = new CollegeRepository();
                if (ColRep.DeleteCollege(id))
                    ViewBag.AlertMsg = "College details deleted successfully";
                return RedirectToAction("GetAllCollegeDetails");

            }
            catch
            {
                return View();
            }
        }
    }
}
