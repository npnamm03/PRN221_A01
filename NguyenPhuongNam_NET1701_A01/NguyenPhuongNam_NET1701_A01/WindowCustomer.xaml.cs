using DataAccessObjects.DTO;
using DataAccessObjects.IRepository;
using DataAccessObjects.Repository;
using System.Windows;
using System.Windows.Controls;

namespace NguyenPhuongNam_NET1701_A01
{
    /// <summary>
    /// Interaction logic for WindowCustomer.xaml
    /// </summary>
    public partial class WindowCustomer : Window
    {
        IBookingReservationRepository bookingReservationRepository = new BookingReservationRepository();
        public int ID { get; set; }
        public int bookingReservationID { get; set; }
        public WindowCustomer()
        {
            InitializeComponent();
        }

        private void btnManageProfile_Click(object sender, RoutedEventArgs e)
        {
            CreateUpdateCustomer createUpdateCustomer = new CreateUpdateCustomer();
            createUpdateCustomer.ID = ID;
            createUpdateCustomer.isMember = true;
            var result = createUpdateCustomer.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ID != 0)
            {
                var data = bookingReservationRepository.GetBookingReservationByCustomerID(ID.ToString());
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
        }
        private string MapStatus(byte? roomStatus)
        {
            if (roomStatus == null)
            {
                return null;
            }
            else if (roomStatus == 0)
            {
                return "InActive";
            }
            else if (roomStatus == 1)
            {
                return "Active";
            }
            else
            {
                throw new InvalidOperationException("Invalid roomStatus value");
            }
        }

        private void btnBookingDetail_Click(object sender, RoutedEventArgs e)
        {
            if (dgData.SelectedItem == null)
            {
                MessageBox.Show("Please select item to view detail");
            }
            else
            {
                BookingDetailPage page = new BookingDetailPage();
                page.bookingReservationID = bookingReservationID.ToString();
                page.ShowDialog();
            }
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem != null)
            {
                CustomBookingReservation selectedRoom = (CustomBookingReservation)dgData.SelectedItem;
                bookingReservationID = selectedRoom.BookingReservationId;
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            WindowLogin loginWindow = new WindowLogin();
            loginWindow.Show();
            this.Close();
        }
    }
}

