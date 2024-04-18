using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NoteApplication_Exam_Bridgeon.Entities.Models.DTO;
using NoteApplication_Exam_Bridgeon.Entities.Models.NoteModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoteApplication_Exam_Bridgeon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;


        public NotesController(INoteRepository notereposity, IMapper mapper)
        {
            _noteRepository = notereposity;
            _mapper = mapper;
        }


        [HttpGet("get-all-notes")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<Note>> GetAllNotes([FromBody] int userId)
        {
            try
            {

                var notes = _noteRepository.GetAllNotesOfUserAsync(userId);
                if (notes != null)
                {
                    return Ok(notes);
                }
                else
                {
                    return NotFound($"No notes found with userId {userId}");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }

        }

        [HttpGet("{id} get-note-by-id")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<Note>> GetNoteById(int userId, int taskId)
        {
            try
            {
                var notesofUser = _noteRepository.GetNotesByIdAsync(userId, taskId);

                if (notesofUser != null)
                {
                    return Ok(notesofUser);
                }
                else
                {
                    return NotFound("User with task or userId not found !");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }

        [HttpPost("Create-note")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Note>> CreateNewNote([FromForm] NoteInputDTO notes, int userId)
        {
            try
            {
                Note mappedNote = _mapper.Map<Note>(notes);
                Note? result = await _noteRepository.CreateNewNote(mappedNote, userId);


                if (result != null)
                {
                    return CreatedAtRoute("get-note-by-id", new { Id = result.NoteId }, result);
                }
                else
                {
                    return NotFound("Note creation can't be completed !");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }




        }




        [HttpDelete("{id} delete-note-by-id")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> DeleteNote(int noteId, int userId)
        {
            try
            {
                bool result = await _noteRepository.DeleteNoteAsync(noteId, userId);

                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound($"Note with note id {noteId} and user Id {userId} Not Found !");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }
    }
}
