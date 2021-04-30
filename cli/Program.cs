using System;
using DIO.Series.Class;
using DIO.Series.Enum;

namespace DIO.Series.CLI
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
            Atividades OpcaoUsuario = 0;
            do
            {
                try
                {
                    OpcaoUsuario = ObterOpcaoUsuario();
                    SelecionarAtividade(OpcaoUsuario);
                }
                catch (Exception ex)
                {
                    switch(ex)
                    {
                        case System.ArgumentOutOfRangeException:
                            Console.WriteLine("Opção inválida informada. Tente novamente.");
                            break;
                        case System.NullReferenceException:
                            Console.WriteLine("Nenhuma opção informada. Digite um número referente à atividade desejada.");
                            break;
                        default:
                            throw;
                    }
                }
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
            Console.WriteLine("Informe o Id da série:");
            int indiceSerie;
            int.TryParse(
                Console.ReadLine(),
                out indiceSerie
            );
            var serie = Repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            throw new NotImplementedException();
        }

        private static void AtualizarSerie()
        {
            throw new NotImplementedException();
        }
        private static Serie ObterDadosSerie()
        {
            foreach (int numeroGenero in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine
                (
                    "{0} {1}",
                    numeroGenero,
                    System.Enum.GetName(typeof(Genero), numeroGenero).Replace("_"," ")
                );
            }

            Console.WriteLine("Informe o número correspondente ao gênero:");
            object generoInformado;
            System.Enum.TryParse(
                typeof(Genero), 
                Console.ReadLine(),
                true,
                out generoInformado
            );

            Console.WriteLine("Informe o título da série:");
            String tituloInformado = Console.ReadLine();

            Console.WriteLine("Informe o ano de início da série:");
            int anoInformado;
            int.TryParse(
                Console.ReadLine(),
                out anoInformado
            );

            Console.WriteLine("Informe a descrição da série:");
            string descricaoInformada = Console.ReadLine();

            Serie novaSerie = new Serie
            (
                id: Repositorio.ProximoId(),
                genero: (Genero) generoInformado,
                titulo: tituloInformado,
                ano: anoInformado,
                descricao: descricaoInformada
            );
            return novaSerie;
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            Serie novaSerie = ObterDadosSerie();

            Repositorio.Insere(novaSerie);
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
            Array ListaAtividades = System.Enum.GetValues(TipoAtividades);
            foreach (var atividade in ListaAtividades)
            {
                Console.WriteLine($"{(int) atividade} - {atividade.ToString().Replace('_',' ')}");
            }
            Console.WriteLine();
            Console.WriteLine("Informe a atividade desejada:");
            String OpcaoUsuario = Console.ReadLine();
            Object Selecao;
            System.Enum.TryParse(TipoAtividades,OpcaoUsuario, true, out Selecao);
            return (Atividades) Selecao;
        }
    }
}
