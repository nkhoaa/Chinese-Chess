using Libs.Data;
using Libs.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        public List<Room> getRoomList();
        public void insertRoom(Room room);
        public int GetHighestRoomNumber();
    }

    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public List<Room> getRoomList() 
        {
            return _dbContext.Rooms.ToList();
        }

        public void insertRoom(Room room)
        {
            _dbContext.Rooms.Add(room);
            _dbContext.SaveChanges();
        }

        public int GetHighestRoomNumber()
        {
            var highestRoom = _dbContext.Rooms
                .Where(r => r.Name.StartsWith("Room "))
                .OrderByDescending(r => r.Name)
                .FirstOrDefault();

            if (highestRoom != null && int.TryParse(highestRoom.Name.Replace("Room ", ""), out int roomNumber))
            {
                return roomNumber;
            }

            return 0; 
        }
    }
}
