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
        [Fact]
        public void SerieRepositorio_AoInvocarMetodoInsere_DeveAcrescentarSerieALista()
        {
        //Given
            int IdSerieFicticia = 0;
            Enum.Genero GeneroSerieFicticia = Enum.Genero.Acao;
            String TituloSerieFicticia = "Série Fictícia";
            int AnoSerieFicticia = 2020;
            String DescricaoSerieFicticia = "Decrição Fictícia";
            SerieRepositorio RepositorioFicticio = new SerieRepositorio();
            Serie SerieFicticia = new Serie(
                IdSerieFicticia,
                GeneroSerieFicticia,
                TituloSerieFicticia,
                AnoSerieFicticia,
                DescricaoSerieFicticia
                );
        //When
            RepositorioFicticio.Insere(SerieFicticia);
            List<Serie> ListaDeSeries = RepositorioFicticio.Lista();
        //Then
            Assert.NotEmpty(ListaDeSeries);
            Assert.All(ListaDeSeries,
                item => item.RetornaTitulo().Contains(TituloSerieFicticia)
            );
        }
        [Fact]
        public void SerieRepositorio_AoInvocarMetodoRetornaPorId_DeveRetornarObjetoTipoSerieEsperado()
        {
        //Given
            int IdSerieFicticia = 0;
            Enum.Genero GeneroSerieFicticia = Enum.Genero.Acao;
            String TituloSerieFicticia = "Série Fictícia";
            int AnoSerieFicticia = 2020;
            String DescricaoSerieFicticia = "Decrição Fictícia";
            SerieRepositorio RepositorioFicticio = new SerieRepositorio();
            Serie SerieFicticia = new Serie(
                IdSerieFicticia,
                GeneroSerieFicticia,
                TituloSerieFicticia,
                AnoSerieFicticia,
                DescricaoSerieFicticia
                );
            RepositorioFicticio.Insere(SerieFicticia);
        //When
            Serie SerieFicticiaRetornada = RepositorioFicticio.RetornaPorId(IdSerieFicticia);
        //Then
            Assert.NotNull(SerieFicticiaRetornada);
            Assert.Equal<Serie>(SerieFicticia,SerieFicticiaRetornada);
        }
        [Fact]
        public void MetodoProximoId_AoSerInvocado_DeveRetornarProximoIndiceDisponivel()
        {
        //Given
            SerieRepositorio RepositorioFicticio = new SerieRepositorio();
        //When
            int ProximoIdObtido = RepositorioFicticio.ProximoId();
            int ProximoIdEsperado = 1;
        //Then
            Assert.Equal(ProximoIdObtido, ProximoIdEsperado);
        }
    }
}