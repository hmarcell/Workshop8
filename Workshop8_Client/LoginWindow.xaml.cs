using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Workshop8_Client
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        string filePath = "C:";

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44349");
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );
            var response = await client.PostAsJsonAsync<LoginViewModel>("auth", new LoginViewModel()
            {
                UserName = tb_username.Text,
                Password = tb_password.Password,
                FolderPath = filePath
            });

            var token = await response.Content.ReadAsAsync<TokenModel>();
            token.Expiration = token.Expiration.ToLocalTime();
            token.FolderPath = filePath;

            MainWindow mw = new MainWindow(token);
            mw.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            rw.ShowDialog();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                lb_filePath.Content = dialog.FileName;
                filePath = dialog.FileName;
            }
        }
    }

    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string FolderPath { get; set; }

    }

    internal class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FolderPath { get; set; }
    }
}
