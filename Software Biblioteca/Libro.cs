using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Biblioteca
{
    class Libro
    {
        private string _autore;

        public string Autore
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("L'autore non può essere vuoto");
                }

                _autore = value;
            }

            get
            {
                return _autore;
            }
        }

        private string _titolo;

        public string Titolo
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Il titolo non puiò essere vuoto");
                }

                _titolo = value;
            }
            get
            {
                return _titolo;
            }
        }

        private string _editore;

        public string Editore
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("L'editore non può essere vuoto");
                }

                _editore = value;
            }

            get
            {
                return _editore;
            }
        }

        private DateTime _pubblicazione;

        public DateTime Pubblicazione
        {
            set
            {
                if(value> DateTime.Today)
                {
                    throw new Exception("Non si può impostare una data di pubblicazione con un anno che ancora non c'è stato");
                }

                _pubblicazione = value;
            }

            get
            {
                return _pubblicazione;
            }
        }

        private int _nPagine;

        public int Pagine
        {
            set
            {
                if(value <= 0)
                {
                    throw new Exception("Il numero delle pagine non può essere minore o uguale a 0");
                }

                _nPagine = value;
            }

            get
            {
                return _nPagine;
            }
        }


        public Libro(string titolo,string autore,string editore,int pagine,DateTime annoPub)
        {
            Titolo = titolo;
            Autore = autore;
            Editore = editore;
            Pagine = pagine;
            Pubblicazione = annoPub;
        }


        public override string ToString()
        {
            return Titolo + " "+Autore;
        }

        public int TempoLetturaOre()
        {
            int tempoLettura = 0;

            if (Pagine < 100)
            {
                tempoLettura = 1;
            }
            else if (Pagine > 100 && Pagine < 200)
            {
                tempoLettura = 2;
            }
            else
            {
                tempoLettura = 3;
            }

            return tempoLettura;
        }
    }
}
