using _21._10.BLL.DTO;
using _21._10.BLL.Interfaces;
using _21._10_ASP_CLASSLIBRARY.EF;
using Microsoft.AspNetCore.Mvc;

namespace _21._10_ASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private INoteService _noteService;
        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<NoteDTO>> GetByIdAsync(int id)
        {
            return Ok(_noteService.GetNote(id));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<NoteDTO>>> GetAllAsync()
        {
            return Ok(await _noteService.GetAllNotesAsync());
        }

        [HttpPost("CreateNote")]
        public async Task<ActionResult> CreateNote(NoteDTO noteDTO)
        {
            _noteService.CreateNote(noteDTO);
            return Ok();
        }

        [HttpDelete("DeleteNote")]
        public async Task<ActionResult> DeleteNodeAsync(int id)
        {
            _noteService.RemoveNote(id);
            return Ok();
        }

        [HttpPut("UpdateNote")]
        public async Task<ActionResult> UpdateNoteAsync(int? id, NoteDTO noteDTO)
        {
            _noteService.UpdateNote(id, noteDTO);
            return Ok();
        }
    }
}