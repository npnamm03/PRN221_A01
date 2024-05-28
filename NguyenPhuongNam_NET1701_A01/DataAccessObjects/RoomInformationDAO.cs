using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class RoomInformationDAO 
    {
        private static RoomInformationDAO? instance;
        private static readonly object instanceLook = new object();
        public RoomInformationDAO() { }
        public static RoomInformationDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new RoomInformationDAO();
                    }
                }
                return instance;
            }
        }
        public IEnumerable<RoomInformation> GetAllRoom()
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                return db.RoomInformations.Include(r => r.RoomType).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public RoomInformation? GetRoomInfoByID(string id)
        {
            int.TryParse(id, out var ID);
            using var db = new FuminiHotelManagementContext();
            RoomInformation? roomInfo = db.RoomInformations.FirstOrDefault(c => c.RoomId == ID);
            return roomInfo;
        }
        public bool UpdateRoom(RoomInformation room)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                db.RoomInformations.Update(room);
                var result = db.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CreateRoom(RoomInformation room)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                db.RoomInformations.Add(room);
                var result = db.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<RoomInformation> SearchRoom(string searchValue)
        {
            var listRoom = new List<RoomInformation>();
            try
            {
                using var db = new FuminiHotelManagementContext();
                listRoom = db.RoomInformations.Where(a => a.RoomNumber == (searchValue) ||
                a.RoomMaxCapacity.ToString() == searchValue).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listRoom;
        }

        public bool DeleteRoom(int id)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                var room = db.RoomInformations.FirstOrDefault(a => a.RoomId == id);
                db.RoomInformations.Remove(room);
                var result = db.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
