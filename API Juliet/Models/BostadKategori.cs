﻿using System.ComponentModel.DataAnnotations;

namespace API_Juliet.Models
{
    public class BostadKategori
    {
        public int Id { get; set; }

        [Required]
        public string Namn { get; set; }
        public string? BildURL { get; set; }
    }
}
