using BusinessObjects;
using DataAccessObjects.IRepository;

namespace DataAccessObjects.Repository
{
    public class RoomRepository : IRoomRepository
    {
        public bool CreateRoom(RoomInformation room)
        {
            return RoomInformationDAO.Instance.CreateRoom(room);
        }

        public bool DeleteRoom(int id)
        {
            return RoomInformationDAO.Instance.DeleteRoom(id);
        }

        public IEnumerable<RoomInformation> GetAllRoom()
        {
            return RoomInformationDAO.Instance.GetAllRoom();
        }

        public RoomInformation? GetRoomInfoByID(string id)
        {
            return RoomInformationDAO.Instance.GetRoomInfoByID(id);
        }

        public List<RoomInformation> SearchRoom(string searchValue)
        {
            return RoomInformationDAO.Instance.SearchRoom(searchValue);
        }

        public bool UpdateRoom(RoomInformation room)
        {
            return RoomInformationDAO.Instance.UpdateRoom(room);
        }
    }
}
