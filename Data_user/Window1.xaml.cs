using System;
using System.Collections.Generic;
using System.IO;
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

namespace Data_user
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private readonly UserViewModel userViewModel = new();
        public Window1()
        {
            InitializeComponent();
            DataContext = userViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // метод передаем в поток
            var thread = new Thread(WriteFile);
            thread.Start();
            MessageBox.Show("Готово!");
        }

        // эта операция будет выполняться в другом потоке и при этом не будет блокировать основной поток визуального представления приложения
        public void WriteFile()
        {
            // 'FileMode' - каким образом открыть // 'FileAccess' - определяет константы для доступа к файлу
            using var filestream = new FileStream(@"C:\Users\Администратор\test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            
            for (int i = 0; i < 1_000_000_000; i++)
            {
                byte[] buf = Encoding.Default.GetBytes(userViewModel.ToString());
                filestream.Write(buf, 0, buf.Length);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }
    }
}
