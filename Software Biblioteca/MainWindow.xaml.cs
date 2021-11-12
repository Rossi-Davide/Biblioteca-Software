using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Software_Biblioteca
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Biblioteca biblioteca;
        public MainWindow()
        {
            InitializeComponent();

            
            //lista creata solo a scopo dimostrativo
            List<Libro> libri = new List<Libro>();

            string data = "23/11/2012";

            DateTime annoPub= DateTime.Parse(data);
            

            libri.Add(new Libro("Learning not to drown","Anna shinoda","Buenavista",200,annoPub));

            //orari creati a scopo dimostrativo
            string apertura = "8:00";
            string chiusura = "12:00";

            List<DateTime> orariApertura = new List<DateTime>();

            orariApertura.Add(DateTime.Parse(apertura));

            List<DateTime> orariChiusura = new List<DateTime>();

            orariChiusura.Add(DateTime.Parse(chiusura));


            biblioteca = new Biblioteca("Malatestiana","piazza",orariApertura,orariChiusura,libri);

            bibliotecaNL.Content = biblioteca.Nome;

            indirizzoBL.Content = biblioteca.Indirizzo;

            orariAL.ItemsSource = null;
            orariCL.ItemsSource = null;

            orariAL.ItemsSource = biblioteca.OrariApertura;
            orariCL.ItemsSource = biblioteca.OrariChiusura;
        }

        private void cercaB_Click(object sender, RoutedEventArgs e)
        {
            if (titoloRB.IsChecked == true)
            {
                Libro l = biblioteca.RicercaTitolo(cercaT.Text);

                cercaLi.Items.Clear();

                cercaLi.Items.Add(l);
            }
            else
            {
                List<Libro> libri = biblioteca.RicercaAutore(cercaT.Text);

                cercaLi.ItemsSource = null;

                cercaLi.ItemsSource = libri;
            }

            
        }

        private void cercaLi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Libro l = (Libro)cercaLi.SelectedItem;

            titoloT.Text = l.Titolo;

            autoreT.Text = l.Autore;

            editoreT.Text = l.Editore;

            nPagineT.Text = l.Pagine.ToString();

            annoT.Text = l.Pubblicazione.Year.ToString();


        }

        private void creaB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int nPagine = int.Parse(nPagineT.Text);

                DateTime data = DateTime.Parse(annoT.Text);

                Libro l = new Libro(titoloT.Text,autoreT.Text,editoreT.Text,nPagine,data);

                biblioteca.Libri.Add(l);

                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
