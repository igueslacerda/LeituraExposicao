using System;
using System.Collections.Generic;
using System.Text;

namespace LeituraExposicao
{
    public static class Formula
    {
        public static double CalcularExposicao(DateTime horaAplicacao, DateTime horaEvento, int distancia, int tempoExposicao)
        {
            double atividade = RetornaAtividade(horaAplicacao, horaEvento);
            // =(0,12*Plan1!F13*POTÊNCIA(10;-3)*(5/60)/POTÊNCIA((50*POTÊNCIA(10;-2));2))*POTÊNCIA(10;4)
            return (0.12 * atividade * Math.Pow(10, -3) * ((Double)tempoExposicao / (Double)60) / Math.Pow(((Double)distancia * Math.Pow(10, -2)), 2)) * Math.Pow(10, 4);
        }

        public static double RetornaAtividade(DateTime horaAplicacao, DateTime horaEvento)
        {
            const double v1 = 25;
            const double v2 = 0.00192;
            const double v4 = -0.115;
            const double v5 = 0.0542;
            const double v9 = 0.566;
            const double v10 = 0.0106;
            const double v11 = 0.549;
            const double v12 = 0.000507;

            // =$B$1*EXP(-$B$2*E2)*($B$4-($B$4*EXP(-$B$5*E2))+$B$9-($B$9*EXP(-$B$10*E2))+$B$11-($B$11*EXP(-$B$12*E2)))
            TimeSpan t = horaEvento - horaAplicacao;
            Double tempo = Math.Round(t.TotalMinutes, 0);

            //    $B$1*EXP(-$B$2*E2)         ($B$4- ($B$4*EXP(-$B$5*E2))       +$B$9-($B$9*EXP(-$B$10*E2))        +$B$11-($B$11 EXP(-$B$12*E2)))
            return v1 * Math.Exp((Double)tempo * -v2) * (v4 - (v4 * Math.Exp(tempo * -v5)) + v9 - (v9 * Math.Exp(tempo * -v10)) + v11 - (v11 * Math.Exp(tempo * -v12)));
        }
    }
}
