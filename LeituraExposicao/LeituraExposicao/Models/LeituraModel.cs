using System;
using System.Collections.Generic;
using System.Text;

namespace LeituraExposicao.Models
{
    public class LeituraModel
    {
        public int ID { get; set; }
        public int Profissional { get; set; }
        public int Paciente { get; set; }
        public int Evento { get; set; }
        public DateTime HoraLeitura { get; set; }
        public int TempoPermanencia { get; set; }
        public decimal Dose { get; set; }
    }
}
