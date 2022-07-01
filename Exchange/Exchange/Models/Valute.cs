﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace exchangeRate
{
    public partial class Valute
    {
       
        public int Id { get; set; }
        public string? NumCode { get; set; }
        public string? CharCode { get; set; }
        public int? Nominal { get; set; }
        public string? Name { get; set; }
        public decimal? Value { get; set; }
        public decimal? Previous { get; set; }
    }
}
