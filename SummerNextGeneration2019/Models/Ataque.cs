﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SummerNextGeneration2019.Models
{
    public class Ataque
    {
        [Range(0,Int32.MaxValue)]
        public int Dano { get; set; }

        [Range(1, 2)]
        public int Jogador { get; set; }
    }
}