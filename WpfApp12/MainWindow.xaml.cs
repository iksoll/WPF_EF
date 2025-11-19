using System.Windows;

namespace WpfApp12
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.ListPage());
        }
    }
}
