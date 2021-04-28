using System;
using DIO.Series.Class;

namespace DIO.Serie.CLI
{
    enum Atividades{
        ListarSerie = 1,
        InserirSerie = 2,
        AtualizarSerie = 3,
        ExcluirSerie = 4,
        VisualizarSerie = 5,
        LimparTela = 6,
        EncerrarPrograma = 7
    }
    class Program
    {
        static SerieRepositorio Repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            String OpcaoUsuario;
            do
            {
                OpcaoUsuario = ObterOpcaoUsuario();
                SelecionarAtividade(OpcaoUsuario);
            } while (OpcaoUsuario != "X");
        }

        private static void SelecionarAtividade(string opcaoUsuario)
        {
            throw new NotImplementedException();
        }

        private static string ObterOpcaoUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
