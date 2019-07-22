using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummerNextGeneration2019.Logic
{
    public static class GameLogic
    {
        public const int PONTOSINICIAIS = 4000;
        public static int PontosJogador1 = PONTOSINICIAIS;
        public static int PontosJogador2 = PONTOSINICIAIS;
        public static int JogadorAtual = -1;

        public static void SubtrairPontos(int pontosDeAtaque)
        {   
            if (JogadorAtual == 2) 
            {
                PontosJogador1 -= pontosDeAtaque;
                if (PontosJogador1 < 0)
                    PontosJogador1 = 0;

            }
            else
                if(JogadorAtual == 1)
            {
                PontosJogador2 -= pontosDeAtaque;
                if (PontosJogador2 < 0)
                    PontosJogador2 = 0;
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