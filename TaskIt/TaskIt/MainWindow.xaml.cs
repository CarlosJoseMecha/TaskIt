using Proyecto_Creacion_Interfaces.Paginas;
using Proyecto_Creacion_Interfaces.Themes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TaskIt
{
   public partial class MainWindow : Window
   {

      public MainWindow()
      {
         InitializeComponent();

         //MouseMove += Window_MouseMove;
         //Para que inicie directamente en la pagina principal
         ContenedorFrame.Navigate(new System.Uri("Paginas/PaginaPrincipal.xaml", UriKind.RelativeOrAbsolute));
      }

      //Controles ventana
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

      // Boton minimizar, maximizar y cerrar
      private void btnClose_Click(object sender, RoutedEventArgs e)
      {
         Close();
      }

      private void btnRestore_Click(object sender, RoutedEventArgs e)
      {
         if (WindowState == WindowState.Normal)
            WindowState = WindowState.Maximized;
         else
            WindowState = WindowState.Normal;
      }

      private void btnMinimize_Click(object sender, RoutedEventArgs e)
      {
         WindowState = WindowState.Minimized;
      }

      private void btnPrincipal_Click(object sender, RoutedEventArgs e)
      {
         ContenedorFrame.Navigate(new System.Uri("Paginas/PaginaPrincipal.xaml", UriKind.RelativeOrAbsolute));
         btnPrincipal.Style = (Style)FindResource("btnMenuActive");
         btnAjuestes.Style = (Style)FindResource("btnMenu");
      }

      private void btnAjustes_Click(object sender, RoutedEventArgs e)
      {
         ContenedorFrame.Navigate(new System.Uri("Paginas/Ajustes.xaml", UriKind.RelativeOrAbsolute));
         btnAjuestes.Style = (Style)FindResource("btnMenuActive");
         btnPrincipal.Style = (Style)FindResource("btnMenu");
      }

   }
}
