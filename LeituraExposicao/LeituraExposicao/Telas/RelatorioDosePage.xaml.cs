using LeituraExposicao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeituraExposicao.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RelatorioDosePage : ContentPage
    {
        public RelatorioDosePage()
        {
            InitializeComponent();

            pikProfissional.ItemsSource = MainPage.Current.CadastroProfissionais;
            pikPaciente.ItemsSource = MainPage.Current.CadastroPacientes;

            dtpFimPeriodo.Date = DateTime.Now.AddDays(1);
        }

        private void btnPesquisar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (pikProfissional.SelectedIndex == -1)
                {
                    DisplayAlert("Atenção", "Informe o profissional.", "Ok");
                    return;
                }

                var leituras = MainPage.Current.CadastroLeituras;
                var eventos = MainPage.Current.ListaEventos;

                var relatorio =
                    from le in leituras
                    where le.Profissional == (pikProfissional.SelectedItem as ProfissionalModel).ID
                       && le.HoraLeitura >= dtpInicioPeriodo.Date && le.HoraLeitura <= dtpFimPeriodo.Date
                       && (pikPaciente.SelectedIndex > -1 ? (le.Paciente == (pikPaciente.SelectedItem as PacienteModel).ID) : true)
                    join evt in eventos on le.Evento equals evt.ID
                    select new { Evento = evt.Descricao, 
                                 HoraLeitura = le.HoraLeitura,
                                 Tempo = le.TempoPermanencia, 
                                 Distancia = evt.Distancia,
                                 Dose = le.Dose};

                BindableLayout.SetItemsSource(stlRelatorio, relatorio);

                var doseTotal = relatorio.Sum(re => re.Dose);
                lblDoseTotal.Text = $"Dose total: {doseTotal:#0.00} μSv";
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
    }
}