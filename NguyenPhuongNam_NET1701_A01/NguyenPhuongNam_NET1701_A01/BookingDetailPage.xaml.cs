using DataAccess.Repository;
using DataAccessObjects.DTO;
using DataAccessObjects.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.Windows;


namespace NguyenPhuongNam_NET1701_A01
{
    /// <summary>
    /// Interaction logic for BookingDetailPage.xaml
    /// </summary>
    public partial class BookingDetailPage : Window
    {
        IBookingDetailRepository bookingDetailRepository = new BookingDetailRepository();
        public string bookingReservationID { get; set; }
        public BookingDetailPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var data = bookingDetailRepository.GetBookDetailByBookingReservationID(bookingReservationID);
            var mapData = from test in data
                          select new CustomBookingDetail
                          {
                              RoomId = test.RoomId,

                              ActualPrice = test.ActualPrice,

                              BookingReservationId = test.BookingReservationId,

                              StartDate = test.StartDate,

                              EndDate = test.EndDate,
                          };
            dgData.ItemsSource = mapData.ToList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text.IsNullOrEmpty())
            {
                var data = bookingDetailRepository.GetBookDetailByBookingReservationID(bookingReservationID);
                var mapData = from test in data
                              select new CustomBookingDetail
                              {
                                  RoomId = test.RoomId,

                                  ActualPrice = test.ActualPrice,

                                  BookingReservationId = test.BookingReservationId,

                                  StartDate = test.StartDate,

                                  EndDate = test.EndDate,
                              };
                dgData.ItemsSource = mapData.ToList();
            }
            else
            {
                var data = bookingDetailRepository.SearchBookingDetail(txtSearch.Text);
                var mapData = from test in data
                              select new CustomBookingDetail
                              {
                                  RoomId = test.RoomId,

                                  ActualPrice = test.ActualPrice,

                                  BookingReservationId = test.BookingReservationId,

                                  StartDate = test.StartDate,

                                  EndDate = test.EndDate,
                              };
                dgData.ItemsSource = mapData.ToList();
            }
        }
    }
}
