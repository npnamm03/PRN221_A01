﻿using BusinessObjects;
using DataAccess.Util;
using DataAccessObjects.IRepository;
using DataAccessObjects.Repository;
using System.Windows;


namespace NguyenPhuongNam_NET1701_A01
{
    /// <summary>
    /// Interaction logic for CreateUpdateRoom.xaml
    /// </summary>
    public partial class CreateUpdateRoom : Window
    {
        public int ID { get; set; }
        IRoomRepository roomRepository = new RoomRepository();
        public CreateUpdateRoom()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ID != 0)
            {
                var room = roomRepository.GetRoomInfoByID(ID.ToString());
                if (room != null)
                {
                    txtDescription.Text = room.RoomDetailDescription;
                    txtMaxCapacity.Text = room.RoomMaxCapacity.ToString();
                    txtRoomNumber.Text = room.RoomNumber;
                    txtRoomPrice.Text = room.RoomPricePerDay.ToString();
                    List<string> statusOptions = new List<string> { "Active", "Inactive" };
                    cboRoomStatus.ItemsSource = statusOptions;
                    int statusValueFromDatabase = (int)room.RoomStatus;
                    cboRoomStatus.SelectedItem = statusValueFromDatabase == 1 ? "Active" : "Inactive";

                    //room type
                    List<string> roomType = new List<string> { "Standard room", "Suite", "Deluxe room", "Executive room", "Family Room", "Connecting Room", "Penthouse Suite", "Bungalow" };
                    cboRoomType.ItemsSource = roomType;
                    int roomTypeValueFromDatabase = (int)room.RoomTypeId;
                    if (roomTypeValueFromDatabase >= 1 && roomTypeValueFromDatabase <= roomType.Count)
                    {
                        cboRoomType.SelectedItem = roomType[roomTypeValueFromDatabase - 1];
                    }
                    btnCreate.IsEnabled = false;
                }
            }
            else
            {
                btnCreate.IsEnabled = true;
                btnUpdate.IsEnabled = false;
                List<string> statusOptions = new List<string> { "Active", "Inactive" };
                cboRoomStatus.ItemsSource = statusOptions;
                cboRoomStatus.SelectedItem = "Active";
                List<string> roomType = new List<string> { "Standard room", "Suite", "Deluxe room", "Executive room", "Family Room", "Connecting Room", "Penthouse Suite", "Bungalow" };
                cboRoomType.ItemsSource = roomType;
                cboRoomType.SelectedItem = "Standard room";
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var validate = ValidationCommon.ValidateRoom(txtRoomNumber.Text.Trim(), txtDescription.Text.Trim(), txtMaxCapacity.Text.Trim(), cboRoomType.SelectedItem.ToString(), cboRoomStatus.SelectedItem.ToString(), txtRoomPrice.Text.Trim());
            if (validate.isValid == false)
            {
                MessageBox.Show(validate.message);
                return;
            }
            else
            {
                List<string> roomType = new List<string> { "Standard room", "Suite", "Deluxe room", "Executive room", "Family Room", "Connecting Room", "Penthouse Suite", "Bungalow" };
                var room = new RoomInformation();
                room.RoomDetailDescription = txtDescription.Text.Trim();
                var capacity = txtMaxCapacity.Text.Trim();
                int.TryParse(capacity, out var maxCapacity);
                room.RoomMaxCapacity = maxCapacity;
                room.RoomNumber = txtRoomNumber.Text.Trim();
                var price = txtRoomPrice.Text.Trim();
                int.TryParse(price, out var roomPrice);
                room.RoomPricePerDay = roomPrice;
                room.RoomStatus = cboRoomStatus.SelectedItem.ToString() == "Active" ? (byte)1 : (byte)0;
                string selectedRoomType = cboRoomType.SelectedItem.ToString();
                int selectedIndex = roomType.IndexOf(selectedRoomType);
                if (selectedIndex >= 0)
                {
                    room.RoomTypeId = selectedIndex + 1;
                }
                var result = roomRepository.CreateRoom(room);
                if (result)
                {
                    MessageBox.Show("Create successfully");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Something went wrong when created");
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var validate = ValidationCommon.ValidateRoom(txtRoomNumber.Text.Trim(), txtDescription.Text.Trim(), txtMaxCapacity.Text.Trim(), cboRoomType.SelectedItem.ToString(), cboRoomStatus.SelectedItem.ToString(), txtRoomPrice.Text.Trim());
            if (validate.isValid == false)
            {
                MessageBox.Show(validate.message);
                return;
            }
            else
            {
                List<string> roomType = new List<string> { "Standard room", "Suite", "Deluxe room", "Executive room", "Family Room", "Connecting Room", "Penthouse Suite", "Bungalow" };
                var room = roomRepository.GetRoomInfoByID(ID.ToString());
                if (room != null)
                {
                    room.RoomDetailDescription = txtDescription.Text.Trim();
                    var capacity = txtMaxCapacity.Text.Trim();
                    int.TryParse(capacity, out var maxCapacity);
                    room.RoomMaxCapacity = maxCapacity;
                    room.RoomNumber = txtRoomNumber.Text.Trim();
                    var price = txtRoomPrice.Text.Trim();
                    int.TryParse(price, out var roomPrice);
                    room.RoomPricePerDay = roomPrice;
                    room.RoomStatus = cboRoomStatus.SelectedItem.ToString() == "Active" ? (byte)1 : (byte)0;
                    string selectedRoomType = cboRoomType.SelectedItem.ToString();
                    int selectedIndex = roomType.IndexOf(selectedRoomType);
                    if (selectedIndex >= 0)
                    {
                        room.RoomTypeId = selectedIndex + 1;
                    }
                }
                var result = roomRepository.UpdateRoom(room);
                if (result)
                {
                    MessageBox.Show("Update successfully");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Something went wrong when updated");
                }
            }
        }
    }
}

