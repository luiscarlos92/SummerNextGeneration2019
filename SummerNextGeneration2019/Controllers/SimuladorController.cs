using SummerNextGeneration2019.Logic;
using SummerNextGeneration2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SummerNextGeneration2019.Controllers
{
    public class SimuladorController : Controller
    {
        public static List<string> Feedback = new List<string>();

        [HttpGet]
        public ActionResult Simulador()
        {
            if (GameLogic.JogadorAtual == -1)
                GameLogic.ReiniciarJogo();
            ViewBag.PontosJogador1 = GameLogic.PontosJogador1;
            ViewBag.PontosJogador2 = GameLogic.PontosJogador2;
            ViewBag.JogadorAtual = GameLogic.JogadorAtual;
            ViewBag.JogoTerminado = GameLogic.JogoTerminado;

            GetFeedbackFromLogic();
            ViewBag.Feedback = new List<string>(Feedback);
            Feedback.Clear();
            return View(new Ataque());
        }

        [HttpPost]
        public ActionResult Atacar(Ataque ataque)
        {
            if (GameLogic.JogoTerminado)
            {
                Feedback.Add("Jogo Terminado, por favor reinicie");
            }
            else
            if (ataque.Dano <= 0)
            {
                Feedback.Add("Por Favor, insira dano");
            }
            else
               if (ModelState.IsValid)
            {
                GameLogic.LogicaDeAtaque(ataque);
            }
            return RedirectToAction("Simulador");
        }

        public ActionResult Reiniciar()
        {
            GameLogic.ReiniciarJogo();
            return RedirectToAction("Simulador");
        }
        public ActionResult FinalizarTurno()
        {
            if (GameLogic.JogoTerminado)
            {
                Feedback.Add("Jogo Terminado, por favor reinicie");
            }
            else
            GameLogic.FinalizarTurno();
            return RedirectToAction("Simulador");
        }

        private void GetFeedbackFromLogic()
        {
            Feedback.AddRange(GameLogic.Feedback);
            GameLogic.Feedback.Clear();
        }
    }
}