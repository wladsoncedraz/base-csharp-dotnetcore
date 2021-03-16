using CadastroCandidato.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace CadastroCandidato.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly CandidatoDAL cand;

        public CandidatoController(CandidatoDAL candidato)
        {
            cand = candidato;
        }
        public IActionResult Index()
        {
            List<Candidato> lstCandidatos = new List<Candidato>();
            lstCandidatos =  cand.GetAllCandidatos().ToList();

            return View(lstCandidatos);
        }

        [HttpGet]
        public IActionResult Details(int? CandidatoID)
        {
            if(CandidatoID == null)
            {
                return NotFound();
            }

            Candidato candidato = cand.GetCandidato(CandidatoID);

            if(candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                cand.AddCandidato(candidato);
                return RedirectToAction("Index");
            }

            return View(candidato);
        }

        [HttpGet]
        public IActionResult Edit(int? CandidatoID)
        {
            if(CandidatoID == null)
            {
                return NotFound();
            }

            Candidato candidato = cand.GetCandidato(CandidatoID);

            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? CandidatoID, [Bind] Candidato candidato)
        {
            if(CandidatoID != candidato.CandidatoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                cand.UpdateCandidato(candidato);
                return RedirectToAction("Index");
            }

            return View(candidato);
        }

        [HttpGet]
        public IActionResult Delete(int? CandidatoID)
        {
            if (CandidatoID == null)
            {
                return NotFound();
            }

            Candidato candidato = cand.GetCandidato(CandidatoID);

            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? CandidatoID)
        {
            cand.DeleteCandidato(CandidatoID);
            return RedirectToAction("Index");
        }
    }
}
