using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummerNextGeneration2019.Logic
{
    public static class GameLogic
    {
        public static int PontosJogador1 = 4000;
        public static int PontosJogador2 = 4000;

        public static int SubtrairPontos(int numeroJogador, int pontosDeAtaque)
        {
            if (numeroJogador == 1) 
            {
                PontosJogador1 -= pontosDeAtaque;
                return PontosJogador1;
            }
            else
            {
                PontosJogador2 -= pontosDeAtaque;
                return PontosJogador2;
            }
        }
    }
}