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

            _courseService.LoadCourse();
        }

        private void ExchangeBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
