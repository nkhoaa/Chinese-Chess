using Libs.Entity;
using Libs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CChess.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private ChessService chessService;

        public RoomController(ChessService chessService)
        {
            this.chessService = chessService;
        }

        [HttpGet("get-room")]
        public ActionResult getRoomList()
        {
            List<Room> roomList = chessService.getRoomList();
            return Ok( new { status = true, message = "", data = roomList } );
        }

        [HttpPost("insert-room")]
        public ActionResult insertRoom() 
        {
            Room r = new Room();
            r.Id = Guid.NewGuid();
            r.Name = chessService.GenerateNextRoomName();
            chessService.insertRoom(r);
            return Ok(new { status = true, message = "", roomId = r.Id } );
        }
    }
}
