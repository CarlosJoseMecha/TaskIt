using Proyecto_Creacion_Interfaces.Themes;
using System;
using System.Windows;
using System.Windows.Controls;
using TaskIt;

namespace Proyecto_Creacion_Interfaces.Paginas
{
   public partial class Ajustes : Page
   {
      public Ajustes()
      {
         InitializeComponent();

         string tema = Properties.Settings.Default.Tema;
         this.Temas.Items.Add("AzulProfundo");
         this.Temas.Items.Add("Purple Haze");
         this.Temas.Items.Add("Atardecer");

         if (tema != null)
         {
            if (tema == "AzulProfundo")
            {
               Temas.SelectedIndex = 0;
            }
            if (tema == "Purple Haze")
            {
               Temas.SelectedIndex = 1;
            }
            if (tema == "Atardecer")
            {
               Temas.SelectedIndex = 2;
            }
         }
         CargarTema();
      }

      private void CambiarTema(object sender, SelectionChangedEventArgs e)
      {
         if (Temas.SelectedIndex == 0)
         {
            Properties.Settings.Default.Tema = "AzulProfundo";
         }
         else if (Temas.SelectedIndex == 1)
         {
            Properties.Settings.Default.Tema = "Purple Haze";
         }
         else if (Temas.SelectedIndex == 2)
         {
            Properties.Settings.Default.Tema = "Atardecer";
         }
         Properties.Settings.Default.Save();
         CargarTema();
      }
      public void CargarTema()
      {
         MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
         Console.WriteLine("Cargando tema");
         Temas temas = new Temas();
         Application.Current.Resources.MergedDictionaries.Clear();
         Application.Current.Resources.MergedDictionaries.Add(temas.CargarTema());
         mainWindow.BtnPrincipal.Style = (Style)FindResource("btnMenu");
         mainWindow.BtnAjustes.Style = (Style)FindResource("btnMenuActive");
      }
   }
}
