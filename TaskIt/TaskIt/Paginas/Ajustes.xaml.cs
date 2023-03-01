using Proyecto_Creacion_Interfaces.Themes;
using System;
using System.Windows;
using System.Windows.Controls;

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
         this.Temas.Items.Add("Aurora");

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
            if (tema == "Aurora")
            {
               Temas.SelectedIndex = 3;
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
         else if (Temas.SelectedIndex == 3)
         {
            Properties.Settings.Default.Tema = "Aurora";
         }
         Properties.Settings.Default.Save();
         CargarTema();
      }
      public void CargarTema()
      {
         Temas temas = new Temas();
         Application.Current.Resources.MergedDictionaries.Clear();
         Application.Current.Resources.MergedDictionaries.Add(temas.CargarTema());
      }
   }
}
