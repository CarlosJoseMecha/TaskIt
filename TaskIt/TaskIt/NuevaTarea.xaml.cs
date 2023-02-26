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
using System.Windows.Shapes;
using TaskIt;

namespace Proyecto_Creacion_Interfaces
{
   public partial class NuevaTarea : Window
   {
      public Tarea nueva_tarea { get; set; }

      public NuevaTarea()
      {
         InitializeComponent();
         nueva_tarea = new Tarea();
         DataContext = nueva_tarea;
      }

      //Controles ventana
      private void Border_MouseDown(object sender, MouseButtonEventArgs e)
      {
         if (e.ChangedButton == MouseButton.Left)
         {
            this.DragMove();
         }
      }
      private void closeButton_Click(object sender, RoutedEventArgs e)
      {
         Close();
      }
      private void Button_Maximize(object sender, RoutedEventArgs e)
      {
         if (this.WindowState == WindowState.Maximized)
         {
            this.WindowState = WindowState.Normal;
         }
         else
         {
            this.WindowState = WindowState.Maximized;
         }
      }
      private void Button_Minimize(object sender, RoutedEventArgs e)
      {
         this.WindowState = WindowState.Minimized;
      }
   }

}
