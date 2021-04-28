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
            int OpcaoUsuario;
            do
            {
                OpcaoUsuario = ObterOpcaoUsuario();
                SelecionarAtividade(OpcaoUsuario);
            } while (OpcaoUsuario != Atividades.EncerrarPrograma);
        }

        private static void SelecionarAtividade(string opcaoUsuario)
        {
            throw new NotImplementedException();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries");
            Console.WriteLine($"{Atividades.ListarSerie} - Listar");
            Console.WriteLine($"{Atividades.InserirSerie} - Inserir");
            Console.WriteLine($"{Atividades.AtualizarSerie} - Atualizar");
            Console.WriteLine($"{Atividades.ExcluirSerie} - Excluir");
            Console.WriteLine($"{Atividades.VisualizarSerie} - Mostrar detalhes");
            Console.WriteLine($"{Atividades.LimparTela} - Limpar tela");
            Console.WriteLine($"{Atividades.EncerrarPrograma} - Encerrar");
            Console.WriteLine();
            Console.WriteLine("Informe a atividade desejada:");
            return Console.ReadLine();
        }
    }
}
