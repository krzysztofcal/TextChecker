using System.Windows;
using TextChecker.ViewModels;

namespace TextChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
        }
    }
}
