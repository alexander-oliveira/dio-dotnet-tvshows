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
            switch (opcaoUsuario)
            {
                case Atividades.Listar:
                    ListarSerie();
                    break;
                case Atividades.Inserir:
                    InserirSerie();
                    break;
                case Atividades.Atualizar:
                    AtualizarSerie();
                    break;
                case Atividades.Excluir:
                    ExcluirSerie();
                    break;
                case Atividades.Visualizar_detalhes:
                    VisualizarSerie();
                    break;
                case Atividades.Limpar_tela:
                    Console.Clear();
                    break;
                case Atividades.Encerrar_programa:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void VisualizarSerie()
        {
            throw new NotImplementedException();
        }

        private static void ExcluirSerie()
        {
            throw new NotImplementedException();
        }

        private static void AtualizarSerie()
        {
            throw new NotImplementedException();
        }

        private static void InserirSerie()
        {
            throw new NotImplementedException();
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listagem de séries");
            dynamic Lista = Repositorio.Lista();
            if(Lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
            }
            else
            {
                String CabecalhoId = "ID";
                String CabecalhoTitulo = "Título";
                String CabecalhoIndicadorExcluido = "Excluído";
                int TamanhoId = 3;
                int TamanhoTitulo = 30;
                int TamanhoIndicadoExcluido = 10;
                Console.WriteLine("{0} {1} {2}",
                    CabecalhoId.PadRight(TamanhoId),
                    CabecalhoTitulo.PadLeft(TamanhoTitulo),
                    CabecalhoIndicadorExcluido.PadRight(TamanhoIndicadoExcluido)
                );
                foreach (Serie serie in Lista)
                {
                    Console.WriteLine("{0} {1} {2}",
                        serie.RetornaId(),
                        serie.RetornaTitulo(),
                        serie.RetornaExcluido() ? "Excluído" : ""
                    );
                }
            }
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
