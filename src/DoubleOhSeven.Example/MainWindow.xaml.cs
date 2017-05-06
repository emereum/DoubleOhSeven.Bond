using System.Windows;

namespace DoubleOhSeven.Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new CounterViewModel();
            InitializeComponent();
        }
    }
}
