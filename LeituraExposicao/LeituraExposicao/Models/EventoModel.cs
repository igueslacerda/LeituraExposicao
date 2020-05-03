using System;
using System.Collections.Generic;
using System.Text;

namespace LeituraExposicao.Models
{
    public class EventoModel
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public int TempoPermanencia { get; set; }
        public int Distancia { get; set; }
    }
}
