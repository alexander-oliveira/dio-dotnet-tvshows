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
        const bool SerieExcluido = false;
        Serie Instancia = new Serie(id: SerieId, genero: SerieGenero, titulo: SerieTitulo, ano: SerieAno, descricao: SerieDescricao);
        [Fact]
        public void Serie_Instanciacao_DeveRetornarObjeto()
        {
        //Given
        //When
        //Then
            Assert.NotNull(Instancia);
            Assert.True(Instancia.Id == SerieId);
        }
        [Fact]
        public void SerieInstanciada_ComArgumentosValidos_DeveRetornarTituloDefinido()
        {
        //Given
        
        //When
        
        //Then
            Assert.True(Instancia.RetornaTitulo() == SerieTitulo);
        }
        [Fact]
        public void SerieInstaciada_ComArgumentosValidos_DeveRetornarId()
        {
        //Given
        
        //When
        
        //Then
            Assert.True(Instancia.RetornaId() == SerieId);
        }
        [Fact]
        public void SerieInstanciada_ComArgumentosValidos_DeveRetornarIndicadorDeExclusao()
        {
        //Given
        
        //When
        
        //Then
            Assert.True(Instancia.RetornaExcluido() == SerieExcluido);
    }
}
