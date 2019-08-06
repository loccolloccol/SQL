using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SQL.Models;

namespace SQL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBManager dbmanager = new DBManager();
            List<Suppliers> supplier = dbmanager.GetSuppliers();
            ViewBag.supplier = supplier;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}