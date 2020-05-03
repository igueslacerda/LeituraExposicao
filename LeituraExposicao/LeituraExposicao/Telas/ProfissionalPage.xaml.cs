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
    public partial class ProfissionalPage : ContentPage
    {
        public ProfissionalPage()
        {
            InitializeComponent();

            var keyboard = Keyboard.Create(KeyboardFlags.CapitalizeWord);
            txtNome.Keyboard = keyboard;
            txtFuncao.Keyboard = keyboard;
        }

        private void Gravar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    DisplayAlert("Atenção", "Preencha o nome do profissional.", "Ok");
                    return;
                }
                if (string.IsNullOrEmpty(txtFuncao.Text))
                {
                    DisplayAlert("Atenção", "Preencha a função profissional.", "Ok");
                    return;
                }

                MainPage.GravarProfissional(new Models.ProfissionalModel
                {
                    Nome = txtNome.Text,
                    Funcao = txtFuncao.Text
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