using SummerNextGeneration2019.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SummerNextGeneration2019.Controllers
{
    public class JogoController : Controller
    {
        // GET: Jogo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tabuleiro()
        {
            ViewBag.PontosJogador1 = GameLogic.PontosJogador1;
            ViewBag.PontosJogador2 = GameLogic.PontosJogador2;

            return View();
        }

    }
}