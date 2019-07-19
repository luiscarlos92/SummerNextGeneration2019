using SummerNextGeneration2019.Logic;
using SummerNextGeneration2019.Models;
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

        [HttpGet]
        public ActionResult Tabuleiro()
        {
            ViewBag.PontosJogador1 = GameLogic.PontosJogador1;
            ViewBag.PontosJogador2 = GameLogic.PontosJogador2;

            return View(new Ataque());
        }

        [HttpPost]
        public ActionResult Atacar(Ataque ataque)
        {
            if (ModelState.IsValid) { 
                GameLogic.SubtrairPontos(ataque.Jogador, ataque.Dano);
            }
            return RedirectToAction("Tabuleiro");
        }

        public ActionResult Reiniciar()
        {
            GameLogic.ReiniciarJogo();
            return RedirectToAction("Tabuleiro");
        }
    }
}