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
            if (GameLogic.JogadorAtual == -1)
                GameLogic.ReiniciarJogo();
            ViewBag.PontosJogador1 = GameLogic.PontosJogador1;
            ViewBag.PontosJogador2 = GameLogic.PontosJogador2;
            ViewBag.JogadorAtual = GameLogic.JogadorAtual;

            return View(new Ataque());
        }

        [HttpPost]
        public ActionResult Atacar(Ataque ataque)
        {
            if (ModelState.IsValid) {
                GameLogic.LogicaDeAtaque(ataque);
            }
            return RedirectToAction("Tabuleiro");
        }

        public ActionResult Reiniciar()
        {
            GameLogic.ReiniciarJogo();
            return RedirectToAction("Tabuleiro");
        }
        public ActionResult FinalizarTurno()
        {
            GameLogic.FinalizarTurno();
            return RedirectToAction("Tabuleiro");
        }
        }
}