using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Files
{
    /// <summary>
    /// Lógica de interacción para Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }
        string path = @"C:\Users\Cristian\source\Repos\Files\UsersAndPasswords.txt";
        private void BtnRegistrer_Click(object sender, RoutedEventArgs e)
        {
            string textToAppend = "\n" + txtUser.Text + "|" + txtPassword.Password;
            File.AppendAllText(path, textToAppend);
            MessageBox.Show("Tu registro fue exitoso, ve y compruébalo tu mismo iniciando sesión", "¡Felicitaciones!");
            txtUser.Text = "";
            txtPassword.Password = "";
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = (MainWindow)Window.GetWindow(this);
            w.mainFrame.NavigationService.Navigate(new Login());
        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Haz accesido a las funciones de administrador. Como administrador, tienes la opción de eliminar los registros de usuarios y contraseñas ¿Estás seguro de que quiere eliminar permanentemente los registros?", "Administrador", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                File.WriteAllText(path, "");
                MessageBox.Show("Los registros fueron borrados de forma exitosa", "¡Solicitud exitosa!");
            }
        }
    }
}
