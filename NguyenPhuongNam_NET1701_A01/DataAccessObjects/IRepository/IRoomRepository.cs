using BusinessObjects;

namespace DataAccessObjects.IRepository
{
    public interface IRoomRepository
    {
        IEnumerable<RoomInformation> GetAllRoom();
        RoomInformation? GetRoomInfoByID(string id);
        bool UpdateRoom(RoomInformation room);
        bool CreateRoom(RoomInformation room);
        List<RoomInformation> SearchRoom(string searchValue);
        bool DeleteRoom(int id);
    }
}
