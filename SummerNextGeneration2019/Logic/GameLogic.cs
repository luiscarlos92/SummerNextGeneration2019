using SummerNextGeneration2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummerNextGeneration2019.Logic
{
    public static class GameLogic
    {
        public static List<string> Feedback = new List<string>();

        public const int PONTOSINICIAIS = 4000;
        public static int PontosJogador1 = PONTOSINICIAIS;
        public static int PontosJogador2 = PONTOSINICIAIS;
        public static int JogadorAtual = -1;

        public static void LogicaDeAtaque(Ataque ataque)
        {
            if (ataque.ModoBloqueio == 0 ||
                (ataque.Dano > ataque.Bloqueio && ataque.ModoBloqueio == 1))
            {
                ReduzDanoAdversario(ataque);
            }
            else
                if (ataque.Dano > ataque.Bloqueio && ataque.ModoBloqueio == 2)
            {
                Feedback.Add("Monstro bloqueante destruido");
            }
            else
                if (ataque.Bloqueio > ataque.Dano)
            {
                ReduzMeuDano(ataque);
            }
            else
                if (ataque.Dano == ataque.Bloqueio && ataque.ModoBloqueio == 1)
                Feedback.Add("Ambos os Monstros destruidos");
        }
        private static void ReduzDanoAdversario(Ataque ataque)
        {
            int diferencadepontos = (ataque.ModoBloqueio!=0) ? ataque.Dano - ataque.Bloqueio : ataque.Dano;

            if (ataque.ModoBloqueio == 1)
                Feedback.Add("Monstro bloqueante destruido");

            ReduzPontosDeJogador(JogadorAtual == 1 ? 2 : 1, diferencadepontos);
        }
        private static void ReduzMeuDano(Ataque ataque)
        {
            int diferencadepontos = ataque.Bloqueio - ataque.Dano;
            ReduzPontosDeJogador(JogadorAtual, diferencadepontos);
        }
        private static void ReduzPontosDeJogador(int numerodejogador, int pontos)
        {
            if (numerodejogador == 1)
            {
                PontosJogador1 -= pontos;

                Feedback.Add("Jogador 1 perdeu " + pontos +  " pontos");
                if (PontosJogador1 < 0)
                    PontosJogador1 = 0;

            }
            else
                    if (numerodejogador == 2)
            {
                PontosJogador2 -= pontos;
                Feedback.Add("Jogador 2 perdeu " + pontos + " pontos");
                if (PontosJogador2 < 0)
                    PontosJogador2 = 0;
            }
        }
        public static void SubtrairPontos(int pontosDeAtaque, int pontosDeBloqueio, int modoBloqueio, bool ataqueDireto)
        {
            
            int jogadorQueLevouNaBoca = JogadorAtual;
            int danosaojogador = pontosDeAtaque - pontosDeBloqueio;
            if (danosaojogador < 0)
            {
                danosaojogador *= -1;
                if (jogadorQueLevouNaBoca == 1)
                    jogadorQueLevouNaBoca = 2;
                else
                   if (jogadorQueLevouNaBoca == 2)
                    jogadorQueLevouNaBoca = 1;
            }


            if (pontosDeBloqueio <= 0 || (pontosDeBloqueio > 0 && modoBloqueio != 2))
            {


                if (jogadorQueLevouNaBoca == 2)
                {
                    PontosJogador1 -= danosaojogador;
                    if (PontosJogador1 < 0)
                        PontosJogador1 = 0;

                }
                else
                    if (jogadorQueLevouNaBoca == 1)
                {
                    PontosJogador2 -= danosaojogador;
                    if (PontosJogador2 < 0)
                        PontosJogador2 = 0;
                }
            }
        }

        public static void ReiniciarJogo()
        {
            PontosJogador1 = PONTOSINICIAIS;
            PontosJogador2 = PONTOSINICIAIS;
            Random rnd = new Random();
            JogadorAtual = rnd.Next(1, 3);
        }

        internal static void FinalizarTurno()
        {
            if (JogadorAtual == 1)
                JogadorAtual = 2;
            else
                if(JogadorAtual == 2)
                JogadorAtual = 1;
        }
    }
}