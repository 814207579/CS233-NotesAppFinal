using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotesAppFinal.Data;
using NotesAppFinal.Models;
using NotesAppFinal.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace NotesAppFinal.Controllers
{
    public class NotesController : Controller
    {
        public readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            List<NoteModel> NoteModelList = _context.NoteModels.ToList();
            return View(NoteModelList);
        }

        [HttpPost]
        public ActionResult Index(NoteModelFilters filters)
        {
            IQueryable<NoteModel> filteredNotes = _context.NoteModels.AsQueryable();

            if(!String.IsNullOrEmpty(filters.Search)) {
                filteredNotes = filteredNotes.Where(t => t.Heading.Contains(filters.Search));
            }
            NoteCategory category;
            if(Enum.TryParse(filters.Category, true, out category))
            {
                filteredNotes = filteredNotes.Where(t => t.categoryId == (int)category);
            }
            ViewBag.filters = filters;
            return View(filteredNotes.ToList());
        }

        public ActionResult Create()
        {
            NotesModelCreate viewModel = new NotesModelCreate();
            viewModel.NoteModel = new NoteModel();
            viewModel.NotesUsers = _context.Users.ToList();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Heading,Content,categoryId,userId")] NoteModel Note)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Note);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Note);
        }


        public ActionResult Edit(int Id)
        {
            NotesModelCreate viewModel = new NotesModelCreate();
            viewModel.NoteModel = _context.NoteModels.Find(Id);
            viewModel.NotesUsers = _context.Users.ToList();
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Heading,Content,categoryId,userId")] NoteModel Note)
        {
            if (ModelState.IsValid)
            {
                _context.Update(Note);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            NotesModelCreate viewModel = new NotesModelCreate();
            viewModel.NoteModel = Note;
            viewModel.NotesUsers = _context.Users.ToList();
            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            NoteModel Note = _context.NoteModels.Find(id);
            _context.Remove(Note);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}