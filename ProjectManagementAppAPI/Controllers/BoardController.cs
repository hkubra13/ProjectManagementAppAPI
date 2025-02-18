using Microsoft.AspNetCore.Mvc;
using ProjectManagementAppAPI.Board.Data.Access;
using ProjectManagementAppAPI.Project.Data.Access;

namespace ProjectManagementAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardController(IBoardRepository boardRepository) : Controller
    {
        private readonly IBoardRepository boardRepository = boardRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllBoards()
        {
            return Ok(await boardRepository.GetAllAsync());
        }

        [HttpGet("ByBoardId/{id}")]
        public async Task<IActionResult> GetBoardById(int id)
        {
            return Ok(await boardRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoard([FromBody] Board.Data.Model.Board board)
        {
            var boardToCreate = await boardRepository.CreateAsync(board);

            if (boardToCreate == null)
                return StatusCode(500, ModelState);

            return Ok("Succesfully created!");
        }

        [HttpPut("{boardId}")]
        public async Task<IActionResult> UpdateBoard([FromBody] Board.Data.Model.Board board, int boardId)
        {
            if (board.BoardId != boardId)
            {
                return StatusCode(500, ModelState);
            }

            return Ok(await boardRepository.UpdateAsync(board));
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBoard(int id)
        {
            return Ok(await boardRepository.DeleteAsync(id));
        }

        [HttpGet("BoardByProjectId/{projectId}")]
        public async Task<IActionResult> GetByProjectId(int projectId)
        {
            return Ok(await boardRepository.GetByProjectIdAsync(projectId));
        }
    }
}
