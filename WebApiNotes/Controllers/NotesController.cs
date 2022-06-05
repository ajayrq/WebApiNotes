using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<NoteDTO> Get()
        {
            NotesManager mgr = new NotesManager();
            return mgr.GetNotes();
        }

        [HttpGet("{id}")]
        public NoteDTO Get(int id)
        {
            NotesManager mgr = new NotesManager();
            return mgr.GetNotes().Where(i=>i.id==id).FirstOrDefault();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(NoteDTO obj)
        {
            NotesManager mgr = new NotesManager();
            mgr.AddNote(obj);
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public void Put(NoteDTO obj)
        {
            NotesManager mgr = new NotesManager();
            mgr.UpdateNote(obj);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            NotesManager mgr = new NotesManager();
            mgr.DeleteNote(id);
        }
    }
}
