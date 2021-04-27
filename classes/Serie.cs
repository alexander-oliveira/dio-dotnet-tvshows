using System;
using DIO.Series.Enum;

namespace DIO.Series.Class
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }
        public Serie(int id, Genero genero, string titulo, int ano, string descricao)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Ano = ano;
            this.Descricao = descricao;
            this.Excluido = false;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }
    }    
}