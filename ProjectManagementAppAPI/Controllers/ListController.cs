using Microsoft.AspNetCore.Mvc;
using ProjectManagementAppAPI.Board.Data.Access;
using ProjectManagementAppAPI.List.Data.Access;

namespace ProjectManagementAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListController(IListRepository listRepository) : Controller
    {
        private readonly IListRepository listRepository = listRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllLists()
        {
            return Ok(await listRepository.GetAllAsync());
        }

        [HttpGet("ByListId/{id}")]
        public async Task<IActionResult> GetListById(int id)
        {
            return Ok(await listRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateList([FromBody] List.Data.Model.List list)
        {
            var listToCreate = await listRepository.CreateAsync(list);

            if (listToCreate == null)
                return StatusCode(500, ModelState);

            return Ok("Succesfully created!");
        }

        [HttpPut("{listId}")]
        public async Task<IActionResult> UpdateList([FromBody] List.Data.Model.List list, int listId)
        {
            if (list.ListId != listId)
            {
                return StatusCode(500, ModelState);
            }

            return Ok(await listRepository.UpdateAsync(list));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteList(int id)
        {
            return Ok(await listRepository.DeleteAsync(id));
        }

        [HttpGet("ListByBoardId/{boardId}")]
        public async Task<IActionResult> GetByBoardId(int boardId)
        {
            return Ok(await listRepository.GetByBoardIdAsync(boardId));
        }
    }
}
