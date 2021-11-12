using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Biblioteca
{
    class Biblioteca
    {

        private string _nome;

        public string Nome
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Il nome non può essere vuoto");
                }

                _nome = value;
            }

            get
            {
                return _nome;
            }
        }

        private string _indirizzo;

        public string Indirizzo
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("L'indirizzo non può essere vuoto");
                }

                _indirizzo = value;
            }

            get
            {
                return _indirizzo;
            }
        }

        public List<DateTime> OrariApertura { set; get; }

        public List<DateTime> OrariChiusura { set; get; }

        public List<Libro> Libri { set; get; }

        public Biblioteca(string nome,string indirizzo,List<DateTime> orariApertura, List<DateTime> orariChiusura, List<Libro> libri)
        {
            Nome = nome;
            Indirizzo = indirizzo;
            OrariApertura = orariApertura;
            OrariChiusura = orariChiusura;
            Libri = libri;
        }

        public Libro RicercaTitolo(string titolo)
        {
            Libro libroReturn = null;
            foreach(Libro l in Libri)
            {
                if(l.Titolo == titolo)
                {
                    libroReturn = l;
                }
            }

            return libroReturn;
        }

        public List<Libro> RicercaAutore(string autore)
        {
            List < Libro > libriRet = new List<Libro>();

            foreach(Libro l in Libri)
            {
                if(l.Autore == autore)
                {
                    libriRet.Add(l);
                }
            }

            return libriRet;
        }
    }
}
