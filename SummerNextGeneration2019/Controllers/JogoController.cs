﻿using SummerNextGeneration2019.Logic;
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
        public static List<string> Feedback = new List<string>();
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

            GetFeedbackFromLogic();
            ViewBag.Feedback = new List<string>(Feedback);
            Feedback.Clear();
            return View(new Ataque());
        }

        [HttpPost]
        public ActionResult Atacar(Ataque ataque)
        {
            if (ataque.Dano <= 0)
            {
                Feedback.Add("Por Favor, insira dano");
            }
            else
               if (ModelState.IsValid)
            {
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

        private void GetFeedbackFromLogic()
        {
            Feedback.AddRange(GameLogic.Feedback);
            GameLogic.Feedback.Clear();
        }
    }
}