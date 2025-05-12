using System.Windows;
using ValueConverter.AppData;

namespace ValueConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CourseService _courseService;
        public MainWindow()
        {
            InitializeComponent();

            _courseService = new CourseService(SellValuteCmb, BuyValuteCmb, SellAmountTB, BuyAmountTB, SellRationTBl, BuyRationTBl, UpdateDateTBl);

        }

        private void ExchangeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _courseService.LoadCourse();

        }
    }
}
