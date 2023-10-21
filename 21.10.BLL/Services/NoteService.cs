using _21._10.BLL.DTO;
using _21._10.BLL.Infrastacture;
using _21._10.BLL.Interfaces;
using _21._10_ASP_CLASSLIBRARY.EF;
using _21._10_ASP_CLASSLIBRARY.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._10.BLL.Services
{
    public class NoteService : INoteService
    {
        NotesContext Database { get; set; }

        public NoteService(NotesContext database)
        {
            Database = database;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public NoteDTO GetNote(int? id)
        {
            if (id == null) return new NoteDTO();
            Note note = Database.Notes.FirstOrDefault(x => x.Id.Equals(id));
            return new NoteDTO() { Id = note.Id, Title = note.Title, Description = note.Description };
        }

        public async Task<ActionResult<IEnumerable<NoteDTO>>> GetAllNotesAsync()
        {
            List<NoteDTO> notes = new List<NoteDTO>();
            if (Database.Notes == null) return notes;
            await Database.Notes.ForEachAsync(x => notes.Add(new NoteDTO(x)));
            return notes;
        }

        public void CreateNote(NoteDTO noteDto)
        {
            Database.Notes.Attach(new Note() { Title = noteDto.Title, Description = noteDto.Description }).State = EntityState.Added;
            Database.SaveChanges();
        }

        public void UpdateNote(int? id, NoteDTO noteDto)
        {
            Note temp = Database.Notes.FirstOrDefaultAsync(x => x.Id.Equals(id)).Result;
            temp.Title = noteDto.Title;
            temp.Description = noteDto.Description;
            Database.Notes.Attach(temp).State = EntityState.Modified;
            Database.SaveChanges();
        }

        public void RemoveNote(int? id)
        {
            Note temp = Database.Notes.FirstOrDefaultAsync(x => x.Id.Equals(id)).Result;
            Database.Notes.Attach(temp).State = EntityState.Deleted;
            Database.SaveChanges();
        }
    }
}
