using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YuGiOhDatabase;

namespace SummerNextGeneration2019.Controllers
{
    public class HomeController : Controller
    {

        private static YuGiOhCardRepository _database;
        public static YuGiOhCardRepository Repo
        {
            get
            {
                if (_database == null)
                    _database = new YuGiOhCardRepository();
                return _database;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //var list = Repo.SearchForMonsters(new SearchFilter()
            //{
            //    Name = "dragon",
            //    FuzzySearch = true
            //}).ToList();

            //var path = Repo.DownloadImage(list[0]);

            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacto dos jovens programadores.";

            return View();
        }
        public ActionResult FoiAvisado()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}