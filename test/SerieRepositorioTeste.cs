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
            int ProximoIdEsperado = 0;
        //Then
            Assert.Equal(ProximoIdObtido, ProximoIdEsperado);
        }
        [Fact]
        public void MetodoExcluir_AoSerInvocado_DeveMarcarIndicadorDeExclusao()
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
            RepositorioFicticio.Exclui(IdSerieFicticia);
        //Then
            bool IndicadorExclusao = RepositorioFicticio.RetornaPorId(IdSerieFicticia).RetornaExcluido();
            Assert.True(IndicadorExclusao);
        }
        [Fact]
        public void MetodoAtualiza_AoSerInvocado_DeveSubstituirObjetoNoRepositorio()
        {
        //Given
            int IdSerieFicticiaA = 0;
            Enum.Genero GeneroSerieFicticiaA = Enum.Genero.Acao;
            String TituloSerieFicticiaA = "Série Fictícia A";
            int AnoSerieFicticiaA = 2020;
            String DescricaoSerieFicticiaA = "Decrição Fictícia A";
            SerieRepositorio RepositorioFicticio = new SerieRepositorio();
            Serie SerieFicticiaA = new Serie(
                IdSerieFicticiaA,
                GeneroSerieFicticiaA,
                TituloSerieFicticiaA,
                AnoSerieFicticiaA,
                DescricaoSerieFicticiaA
                );
            RepositorioFicticio.Insere(SerieFicticiaA);
            int IdSerieFicticiaB = 0;
            Enum.Genero GeneroSerieFicticiaB = Enum.Genero.Documentario;
            String TituloSerieFicticiaB = "Série Fictícia B";
            int AnoSerieFicticiaB = 2021;
            String DescricaoSerieFicticiaB = "Decrição Fictícia B";
            Serie SerieFicticiaB = new Serie(
                IdSerieFicticiaB,
                GeneroSerieFicticiaB,
                TituloSerieFicticiaB,
                AnoSerieFicticiaB,
                DescricaoSerieFicticiaB
                );
        //When
            RepositorioFicticio.Atualiza(IdSerieFicticiaA,SerieFicticiaB);
            Serie SerieRetornada = RepositorioFicticio.RetornaPorId(IdSerieFicticiaA);
        //Then
            Assert.Equal(SerieRetornada,SerieFicticiaB);
            Assert.NotEqual(SerieRetornada, SerieFicticiaA);
        }
    }
}