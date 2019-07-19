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

        public static void SubtrairPontos(int numeroJogador, int pontosDeAtaque)
        {   
            if (numeroJogador == 1) 
            {
                PontosJogador1 -= pontosDeAtaque;
                if (PontosJogador1 < 0)
                    PontosJogador1 = 0;

            }
            else
                if(numeroJogador == 2)
            {
                PontosJogador2 -= pontosDeAtaque;
                if (PontosJogador2 < 0)
                    PontosJogador2 = 0;
            }
        }
    }
}