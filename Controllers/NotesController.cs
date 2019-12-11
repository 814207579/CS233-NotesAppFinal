using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotesAppFinal.Data;
using NotesAppFinal.Models;
using NotesAppFinal.ViewModels;

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

        public ActionResult Create()
        {
            NotesModelCreate viewModel = new NotesModelCreate();
            viewModel.NoteModel = new NoteModel();
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
            return View(Note);
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