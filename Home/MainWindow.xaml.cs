using Home.ViewModel;
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

namespace Home
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // для определения контекста взаимодействия с нашей viewmodel
            DataContext = new UserViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var addData = new AddData();
            addData.Show();

            Close();
        }
    }
}