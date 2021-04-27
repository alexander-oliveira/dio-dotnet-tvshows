using System;
using System.Collections.Generic;
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
        [Fact]
        public void SerieRepositorio_AoinvocarMetodoLista_DeveRetornarListaDoTipoSerie()
        {
        //Given
            SerieRepositorio RepositorioFicticio = new SerieRepositorio();
        //When
            Object ListaDeSeries = RepositorioFicticio.Lista();
        //Then
            Assert.NotNull(ListaDeSeries);
            Assert.IsType<List<Serie>>(ListaDeSeries);
        }
    }
}