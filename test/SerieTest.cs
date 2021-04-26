using System;
using Xunit;
using DIO.Series.Class;
using DIO.Series.Enum;

namespace DIO.Series.Test
{
    public class SerieTest
    {
        const int SerieId = 0;
        const Genero SerieGenero = Genero.Acao;
        const String SerieTitulo = "Serie ficticia";
        const int SerieAno = 2021;
        const string SerieDescricao = "Descricao ficticia";
        Serie Instancia;
        
        [Fact]
        public void Serie_Instanciacao_Sucesso()
        {
        //Given
        //When
            Instancia = new Serie(id: SerieId, genero: SerieGenero, titulo: SerieTitulo, ano: SerieAno, descricao: SerieDescricao);
        //Then
            Assert.NotNull(Instancia);
        }
    }
}
