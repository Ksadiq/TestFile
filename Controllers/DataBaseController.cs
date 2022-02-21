using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppExam_21.Models;

namespace WebAppExam_21.Controllers
{
    public class DataBaseController : Controller
    {
        public ActionResult AllDresses()
        {
            var com = new DataContent();
            var shping = com.GetAllDresses();
            return View(shping);
        }

        public ActionResult OnEdit(string Id)
        {
            int shopapp_Id = Convert.ToInt32(Id);
            var component = new DataContent();
            try
            {
                var shp = component.FindDresses(shopapp_Id);
                return View(shp);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult OnEdit(Shopping postedData)
        {
            var component = new DataContent();
            try
            {
                component.UpdateDresses(postedData);
                return RedirectToAction("AllDresses");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult AddDresses()
        {
            return View(new Shopping());
        }

        [HttpPost]
        public ActionResult AddStudent(Shopping postedRec)
        {
            var com = new DataContent();
            com.AddNewDresses(postedRec);
            return RedirectToAction("AllDresses");
        }

        [HttpGet]
        public ActionResult UpdateDresses(int id)
        {
           int shopapp_Id = Convert.ToInt32(id);
            var com = new DataContent();
            try
            {
                var update = com.FindDresses(id);
                return View(update);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult UpdateDresses(Shopping post)
        {
            var com = new DataContent();
            try
            {
                com.UpdateDresses(post);
                return RedirectToAction("AllDresses");
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public ActionResult Delete(string id)
        {
            int shopapp_Id = Convert.ToInt32(id);
            var com = new DataContent();
            try
            {
                com.DeleteDresses(shopapp_Id);
                return RedirectToAction("AllDresses");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}