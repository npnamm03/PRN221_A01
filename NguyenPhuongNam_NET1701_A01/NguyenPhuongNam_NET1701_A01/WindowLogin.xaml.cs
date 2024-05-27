using DataAccess.Util;
using DataAccessObjects.Enum;
using DataAccessObjects.IRepository;
using DataAccessObjects.Repository;
using System.Windows;

namespace NguyenPhuongNam_NET1701_A01
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        ICustomerRepository customerRepository = new CustomerRepository();
        public WindowLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = ValidationLogin.ValidateData(txtEmail.Text, txtPassword.Password);
                if (result.isValid)
                {
                    Role login = customerRepository.CheckLogin(txtEmail.Text, txtPassword.Password);
                    if (login == Role.Admin)
                    {
                        WindowAdmin screen = new WindowAdmin();
                        this.Close();
                        screen.ShowDialog();
                    }
                    else if (login == Role.Customer)
                    {
                        var customer = customerRepository.GetCustomerByCondition(c => c.EmailAddress.Equals(txtEmail.Text)).FirstOrDefault();
                        WindowCustomer memberScreen = new WindowCustomer();
                        memberScreen.ID = customer.CustomerId;
                        this.Close();
                        memberScreen.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("User not found");
                    }
                }
                else
                {
                    MessageBox.Show(result.message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
