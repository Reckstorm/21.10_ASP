using _21._10.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._10.BLL.Interfaces
{
    public interface INoteService
    {
        void CreateNote(NoteDTO noteDto);
        void UpdateNote(int? id, NoteDTO noteDto);
        NoteDTO GetNote(int? id);
        Task<ActionResult<IEnumerable<NoteDTO>>> GetAllNotesAsync();
        void RemoveNote(int? id);
        void Dispose();
    }
}
