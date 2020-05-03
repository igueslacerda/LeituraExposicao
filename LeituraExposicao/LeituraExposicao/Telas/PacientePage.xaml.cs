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
    public partial class PacientePage : ContentPage
    {
        public PacientePage()
        {
            InitializeComponent();
            var keyboard = Keyboard.Create(KeyboardFlags.CapitalizeWord);
            txtNome.Keyboard = keyboard;
        }

        private void Gravar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    DisplayAlert("Atenção", "Preencha o nome do paciente.", "Ok");
                    return;
                }

                MainPage.GravarPaciente(new Models.PacienteModel
                {
                    Nome = txtNome.Text,
                    DataAplicacao = new DateTime(
                        dtpData.Date.Year,
                        dtpData.Date.Month,
                        dtpData.Date.Day,
                        tmpHora.Time.Hours,
                        tmpHora.Time.Minutes,
                        tmpHora.Time.Seconds
                        )
                });
                Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
    }
}