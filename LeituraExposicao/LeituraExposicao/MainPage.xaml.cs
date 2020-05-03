using LeituraExposicao.Models;
using LeituraExposicao.Telas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace LeituraExposicao
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static MainPage Current => (App.Current.MainPage as NavigationPage).RootPage as MainPage;

        #region Persistência dos cadastros
        public List<ProfissionalModel> CadastroProfissionais = new List<ProfissionalModel>();
        public List<EventoModel> ListaEventos = new List<EventoModel> {
            new EventoModel{ ID = 1, Descricao = "Verificação dos sinais vitais", TempoPermanencia = 5, Distancia = 50},
            new EventoModel{ ID = 2, Descricao = "Higiene e conforto do paciente", TempoPermanencia = 20, Distancia = 50},
            new EventoModel{ ID = 3, Descricao = "Medicação", TempoPermanencia = 5, Distancia = 50},
            new EventoModel{ ID = 4, Descricao = "Esvaziamento da bolsa coletora", TempoPermanencia = 5, Distancia = 20},
        };
        public List<PacienteModel> CadastroPacientes = new List<PacienteModel>();
        public List<LeituraModel> CadastroLeituras = new List<LeituraModel>();
        #endregion

        #region Métodos de cadastro
        public static void GravarProfissional(ProfissionalModel model)
        {
            if (Current.CadastroProfissionais.Count == 0)
                model.ID = 1;
            else
                model.ID = (Current.CadastroProfissionais?.Max(p => p.ID) ?? 0) + 1;
            Current.CadastroProfissionais.Add(model);
        }

        public static void GravarPaciente(PacienteModel model)
        {
            if (Current.CadastroPacientes.Count == 0)
                model.ID = 1;
            else
                model.ID = (Current.CadastroPacientes?.Max(p => p.ID) ?? 0) + 1;
            Current.CadastroPacientes.Add(model);
        }

        public static void GravarLeitura(LeituraModel model)
        {
            if (Current.CadastroLeituras.Count == 0)
                model.ID = 1;
            else
                model.ID = (Current.CadastroLeituras?.Max(p => p.ID) ?? 0) + 1;
            Current.CadastroLeituras.Add(model);
        }
        #endregion

        public MainPage()
        {
            InitializeComponent();

            CadastroProfissionais = new List<ProfissionalModel>();
        }

        private void Profissional_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfissionalPage());
        }

        private void Paciente_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PacientePage());
        }

        private void Leitura_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LeituraPage());
        }

        private void RelatorioDose_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RelatorioDosePage());
        }

        private void RelatorioDoseEfetiva_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RelatorioDoseEfetivaPage());
        }
    }
}
