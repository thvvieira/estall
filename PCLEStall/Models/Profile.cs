using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCLEStall.Models
{
    public class Profile
    {
        public int Handle { get; set; }
        public string Nome { get; set; }
        public string Identificacao { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataAdmissao { get; set; }
        public byte[] Imagem { get; set; }
        public bool Viaja { get; set; }
        public int TipoColaborador { get; set; }
    }
}
