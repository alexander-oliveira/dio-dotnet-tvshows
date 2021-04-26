using System;
using DIO.Series.Enum;

namespace DIO.Series.Class
{
    public class Serie : EntidadeBase
    {
        public Serie(int id, Genero genero, string titulo, int ano, string descricao)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Ano = ano;
            Descricao = descricao;
        }

        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

    }    
}