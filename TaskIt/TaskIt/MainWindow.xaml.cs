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

namespace TaskIt
{
   /// <summary>
   /// Lógica de interacción para MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
         MouseMove += Window_MouseMove;

         //Inicializacion ListBox
         List<Tarea> tareas = new List<Tarea>();
         tareas.Add(new Tarea() { nombre_tarea = "Mi tarea 1", fecha = "26/02/2023" });
         tareas.Add(new Tarea() { nombre_tarea = "Mi tarea 2", fecha = "26/02/2023" });
         tareas.Add(new Tarea() { nombre_tarea = "Mi tarea 3", fecha = "26/02/2023" });
         tareas.Add(new Tarea() { nombre_tarea = "Mi tarea 4", fecha = "26/02/2023" });

         Tareas.ItemsSource = tareas;
      }

      private void Border_MouseDown(object sender, MouseButtonEventArgs e)
      {
         if (e.ChangedButton == MouseButton.Left)
         {
            this.DragMove();
         }
      }

      private void Window_MouseMove(object sender, MouseEventArgs e)
      {
         if (e.LeftButton == MouseButtonState.Pressed && WindowState == WindowState.Maximized)
         {
            double mouseX = e.GetPosition(this).X;
            double windowHeight = ActualHeight;
            double windowTop = e.GetPosition(this).Y;
            double windowLeft = (mouseX / ActualWidth) * (SystemParameters.PrimaryScreenWidth - RestoreBounds.Width);
            Top = windowTop - (windowHeight);
            Left = windowLeft;
            WindowState = WindowState.Normal;
            DragMove();
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

   public class Tarea
   {
      public string nombre_tarea { get; set; }
      public string fecha { get; set; }
   }
}
