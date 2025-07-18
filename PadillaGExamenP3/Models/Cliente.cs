﻿using SQLite;

namespace PadillaGExamenP3.Models
{
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Empresa { get; set; }
        public int AntiguedadMeses { get; set; }
        public bool Activo { get; set; }
    }
}
