using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Workshop8_Client
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        RegisterViewModel model = new RegisterViewModel();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tb_password.Password != tb_password2.Password)
            {
                MessageBox.Show("Passwords not match!", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5095");
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

                var response = await client.PutAsJsonAsync<RegisterViewModel>("auth", model);
                model.UserName = tb_username.Text;
                model.Password = tb_password.Password;

                if (response.IsSuccessStatusCode)
                {
                    var result = MessageBox.Show("Registration succesful", "Info", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    this.DialogResult = true;
                }
            }
        }
    }

    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
