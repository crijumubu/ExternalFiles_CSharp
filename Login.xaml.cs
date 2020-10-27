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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        string path = @"C:\Users\Cristian\source\Repos\Files\UsersAndPasswords.txt";
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool correctInformation = false;
            string s = "|";
            char c = Convert.ToChar(s);
            string[] content = File.ReadAllLines(path);
            for (int i=0; i<content.Length ; i++)
            {
                string user = "";
                string password = "";
                int count = 0;
                foreach (char j in content[i])
                {
                    if (j != c)
                    {
                        if (count == 0)
                        {
                            user += j;
                        }
                        else
                        {
                            password += j;
                        }
                    }
                    else
                    {
                        count = 1;
                    }
                }
                if(txtUser.Text==user && txtPassword.Password == password)
                {
                    correctInformation = true;
                    MessageBox.Show("Tu inicio de sesión fue exitoso. Pronto podrás acceder a las diferentes funcionalidades de la aplicación, estamos trabajando en ello", "¡Bienvenido!");
                    txtUser.Text = "";
                    txtPassword.Password = "";
                    break;
                }
            }
            if (correctInformation == false)
            {
                MessageBox.Show("Usuario y/o contraseña errónea","¡Error!");
            }
        }
        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = (MainWindow)Window.GetWindow(this);
            w.mainFrame.NavigationService.Navigate(new Register());
        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Haz accesido a las funciones de administrador. Como administrador, tienes la opción de eliminar los registros de usuarios y contraseñas ¿Estás seguro de que quiere eliminar permanentemente los registros?", "Administrador", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                File.WriteAllText(path,"");
                MessageBox.Show("Los registros fueron borrados de forma exitosa","¡Solicitud exitosa!");
            }
        }
    }
}
