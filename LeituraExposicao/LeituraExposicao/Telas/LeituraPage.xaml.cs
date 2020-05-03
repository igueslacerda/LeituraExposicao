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
    public partial class LeituraPage : ContentPage
    {
        public LeituraPage()
        {
            InitializeComponent();

            pikProfissional.ItemsSource = MainPage.Current.CadastroProfissionais;
            pikPaciente.ItemsSource = MainPage.Current.CadastroPacientes;
            pikEvento.ItemsSource = MainPage.Current.ListaEventos;
        }

        private void pikEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            var model = (sender as Picker).SelectedItem as EventoModel;
            lblDistanciaEvento.Text = $"{model.Distancia} cm do paciente";
            txtTempoPermanencia.Text = model.TempoPermanencia.ToString();
        }

        private void Gravar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (pikProfissional.SelectedIndex == -1)
                {
                    DisplayAlert("Atenção", "Selecione o profissional.", "Ok");
                    return;
                }
                if (pikPaciente.SelectedIndex == -1)
                {
                    DisplayAlert("Atenção", "Selecione o paciente.", "Ok");
                    return;
                }
                if (pikEvento.SelectedIndex == -1)
                {
                    DisplayAlert("Atenção", "Selecione o evento.", "Ok");
                    return;
                }
                int.TryParse(txtTempoPermanencia.Text, out int tempo);
                if (tempo <= 0)
                {
                    DisplayAlert("Atenção", "Informe um tempo de permanência válido.", "Ok");
                    return;
                }

                var paciente = pikPaciente.SelectedItem as PacienteModel;
                var horaLeitura = new DateTime(
                        dtpDataLeitura.Date.Year,
                        dtpDataLeitura.Date.Month,
                        dtpDataLeitura.Date.Day,
                        tmpHoraLeitura.Time.Hours,
                        tmpHoraLeitura.Time.Minutes,
                        tmpHoraLeitura.Time.Seconds
                        );

                var leitura = new LeituraModel
                {
                    Profissional = (pikProfissional.SelectedItem as ProfissionalModel).ID,
                    Paciente = paciente.ID,
                    Evento = (pikEvento.SelectedItem as EventoModel).ID,
                    HoraLeitura = horaLeitura,
                    TempoPermanencia = tempo
                };

                var dose = Formula.CalcularExposicao(paciente.DataAplicacao, horaLeitura, (pikEvento.SelectedItem as EventoModel).Distancia, tempo);

                leitura.Dose = Convert.ToDecimal(dose);

                MainPage.GravarLeitura(leitura);
                Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
    }
}