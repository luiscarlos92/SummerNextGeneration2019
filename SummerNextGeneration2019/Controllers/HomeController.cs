using System;
using System.Collections.Generic;
using System.IO;
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
        private string LoadImageToServer(string systemFilePath)

        {

            string downloadFilePath = systemFilePath;

            string serverFolderPath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.GetData("DataDirectory").ToString()).FullName, "images");

            if (!Directory.Exists(serverFolderPath))

                Directory.CreateDirectory(serverFolderPath);

            string fileName = Path.GetFileName(downloadFilePath);

            string serverFilePath = Path.Combine(serverFolderPath, fileName);

            if (!System.IO.File.Exists(serverFilePath))

                System.IO.File.Copy(downloadFilePath, serverFilePath);

            return fileName;

        }

        public ActionResult Index()
        {
            var list = Repo.SearchForMonsters(new SearchFilter()
            {
            }).ToList();

            ViewBag.Image1 = LoadImageToServer(Repo.DownloadImage(list[new Random().Next(0, list.Count)]));
            ViewBag.Image2 = LoadImageToServer(Repo.DownloadImage(list[new Random().Next(0, list.Count)]));
            ViewBag.Image3 = LoadImageToServer(Repo.DownloadImage(list[new Random().Next(0, list.Count)]));

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