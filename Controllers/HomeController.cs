using Microsoft.AspNetCore.Mvc;
using Tp6.Models;
namespace Tp6.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.ListaPartidos = BD.ListarPartidos();
        return View();
    }
    public IActionResult DetallePartido(int IdPartido)
    {
        ViewBag.ListaCandidatos = BD.ListarCandidatos(IdPartido);
        ViewBag.InfoPartido = BD.InfoPartido(IdPartido);
        return View("DetallePartido");
    }

    public IActionResult DetalleCandidato(int IdCandidato)
    {
        ViewBag.InfoCandidato = BD.InfoCandidato(IdCandidato);
        return View("DetalleCandidato");
    }

    public IActionResult AgregarCandidato(int IdPartido)
    {
        ViewBag.IdPartido = IdPartido;
        return View("AgregarCandidato");
    }

    public IActionResult GuardarCandidato(Candidato can)
    {
        BD.AgregarCandidato(can);
        return RedirectToAction("DetallePartido",new{IdPartido=can.FkPartido});
    }

    public IActionResult EliminarCandidato(int IdCandidato, int IdPartido)
    {
        BD.EliminarCandidato(IdCandidato);
        return RedirectToAction("DetallePartido",new{IdPartido=IdPartido});
    }

    public IActionResult ConfirmarEliminarCandidato(int IdCandidato, int IdPartido){

        ViewBag.IdPartido=IdPartido;
        ViewBag.InfoCandidato=BD.InfoCandidato(IdCandidato);
        return View("ConfirmarEliminarCandidato");
    }

    public IActionResult Elecciones()
    {
        return View();
    }
    public IActionResult Creditos()
    {
        return View();
    }
}

