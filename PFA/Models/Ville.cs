﻿namespace AuthSystem.Models
{
    public class Ville
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public IList<Endroit> Endroit { get; set; }
    }
}
