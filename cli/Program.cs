using System;
using DIO.Series.Class;

namespace DIO.Serie.CLI
{
    enum Atividades : int
    {
        Listar = 1,
        Inserir = 2,
        Atualizar = 3,
        Excluir = 4,
        Visualizar_detalhes = 5,
        Limpar_tela = 6,
        Encerrar_programa = 7
    }
    class Program
    {
        static SerieRepositorio Repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            Atividades OpcaoUsuario;
            do
            {
                OpcaoUsuario = ObterOpcaoUsuario();
                SelecionarAtividade(OpcaoUsuario);
            } while (OpcaoUsuario != Atividades.Encerrar_programa);
        }

        private static void SelecionarAtividade(Atividades opcaoUsuario)
        {
            throw new NotImplementedException();
        }

        private static Atividades ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries");
            Type TipoAtividades = typeof(Atividades);
            Array ListaAtividades = Enum.GetValues(TipoAtividades);
            foreach (var atividade in ListaAtividades)
            {
                Console.WriteLine($"{(int) atividade} - {atividade.ToString().Replace('_',' ')}");
            }
            Console.WriteLine();
            Console.WriteLine("Informe a atividade desejada:");
            String OpcaoUsuario = Console.ReadLine();
            return (Atividades) Enum.Parse(typeof(Atividades),OpcaoUsuario);
        }
    }
}
