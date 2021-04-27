using System;
using Xunit;
using DIO.Series.Interfaces;
using DIO.Series.Class;
namespace DIO.Series.Test
{
    public class SerieRepositorioTeste
    {
        [Fact]
        public void SerieRepositorio_AoInstanciar_DeveRetornarObjetoTipoIRepositorio()
        {
        //Given
            SerieRepositorio RepositorioFicticio;
        //When
            RepositorioFicticio = new SerieRepositorio();
        //Then
            Assert.NotNull(RepositorioFicticio);
            Assert.IsType<SerieRepositorio>(RepositorioFicticio);
            Assert.IsAssignableFrom<IRepositorio<Serie>>(RepositorioFicticio);
        }
    }
}