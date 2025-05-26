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

        private void SellAmountTB_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (_courseService != null)
            {
                _courseService.ConvertValute();
            }
        }

        private void SellValuteCmb_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (_courseService != null)
            {
                _courseService.ConvertValute();
            }
        }

        private void BuyValuteCmb_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (_courseService != null)
            {
                _courseService.ConvertValute();
            }
        }

        private void BuyAmountTB_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (_courseService != null)
            {
                _courseService.ConvertValute();
            }
        }
    }
}
