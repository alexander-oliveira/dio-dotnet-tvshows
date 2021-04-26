using System;
using Xunit;
using DIO.Series.Class;

namespace DIO.Series.Test
{
    public class SerieTest
    {
        [Fact]
        public void Serie_Instanciacao_Sucesso()
        {
        //Given
            const int SerieId = 0;
            const Genero SerieGenero = Genero.Acao;
            const String SerieTitulo = "Serie ficticia";
            const int SerieAno = 2021;
            const string SerieDescricao = "Descricao ficticia";
            Serie Instancia;
        //When
            Instancia = new Serie(id: SerieId, genero: SerieGenero, titulo: SerieTitulo, ano: SerieAno, descricao: SerieDescricao);
        //Then
            Assert.NotNull(Instancia);
        }
    }
}
