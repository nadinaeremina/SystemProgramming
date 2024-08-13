using System.Diagnostics;
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

namespace CallOtherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Process? process;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // запускаем другое приложение пр ссылке
            // 1
            process = Process.Start("C:\\Users\\Nadya\\source\\repos\\System_programming\\WpfApp1\\bin\\Debug\\net8.0-windows\\WpfApp1.exe");
            
            // 2 
            //using(var process = Process.Start("C:\\Users\\Nadya\\source\\repos\\System_programming\\WpfApp1\\bin\\Debug\\net8.0-windows\\WpfApp1.exe"))
            //{
            //    // работа с процессом
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            process?.CloseMainWindow(); // может произойти только с теми приложениями, у которых есть графический процесс
            
            //process?.Close(); // после того, как завершили - не сможем обращаться к данному процессу, как к экземпляру
            
            // process?.Kill(); // все ресурсы очистятся - процесс полностью убит // но обратиться можно будет

            // идентично следующему
            //if (process != null)
            //    process.Kill();

            //process = null; // обратиться не сможем
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (process != null)
                MessageBox.Show(process.Id.ToString());
        }
    }
}