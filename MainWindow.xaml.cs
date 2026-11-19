using Npgsql;
using System;
using System.Text;
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

namespace _1._7
{
    public partial class MainWindow : Window
    {
        private const string ConnectionString = "Host=SQLstudv2;Port=5432;Database=23ip_26;Username=23ip_26;Password=23ip_26";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TestConnection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("SELECT version();", conn))
                    {
                        var version = cmd.ExecuteScalar()?.ToString();
                        MessageBox.Show("Подключение успешно!\nВерсия сервера:\n" + version);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения:\n" + ex.Message);
            }
        }
    }
}