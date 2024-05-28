using DataAccessObjects.DTO;
using DataAccessObjects.IRepository;
using DataAccessObjects.Repository;
using System.Windows;

namespace NguyenPhuongNam_NET1701_A01
{
    /// <summary>
    /// Interaction logic for ReportStatic.xaml
    /// </summary>
    public partial class ReportStatic : Window
    {
        IBookingReservationRepository bookRepository = new BookingReservationRepository();
        public ReportStatic()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            startDatePicker.SelectedDate = DateTime.Now;
            endDatePicker.SelectedDate = DateTime.Now;
        }

        private void btnStatistic_Click(object sender, RoutedEventArgs e)
        {
            var startDate = startDatePicker.SelectedDate ?? DateTime.Today;
            var endDate = endDatePicker.SelectedDate ?? DateTime.Today;
            var data = bookRepository.GetAllBookingReservationByDate(startDate, endDate);
            var mapData = from test in data
                          select new CustomBookingReservation
                          {
                              BookingDate = test.BookingDate,

                              BookingReservationId = test.BookingReservationId,

                              BookingStatus = MapStatus(test.BookingStatus),

                              CustomerId = test.CustomerId,

                              TotalPrice = test.TotalPrice
                          };
            dgData.ItemsSource = mapData.ToList();
        }
        private string MapStatus(byte? roomStatus)
        {
            if (roomStatus == null)
            {
                return null;
            }
            else if (roomStatus == 0)
            {
                return "Active";
            }
            else if (roomStatus == 1)
            {
                return "Inactive";
            }
            else
            {
                throw new InvalidOperationException("Invalid roomStatus value");
            }
        }
    }
}
