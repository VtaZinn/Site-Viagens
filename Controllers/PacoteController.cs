using System.Collections.Generic;
using atividade2CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace atividade2CRUD.Controllers


{
    public class PacoteController : Controller {

        public IActionResult Lista(){
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");
            PacoteBanco pacoteBanco = new PacoteBanco();
            List<Pacote> Lista = pacoteBanco.Listar();
            return View(Lista);
        }

        public IActionResult Cadastro(){
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Pacote pacote){
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");
            PacoteBanco pacoteBanco = new PacoteBanco();
            int idUsuario = HttpContext.Session.GetInt32("IdUsuario") ?? 0;
            pacote.Id = idUsuario;
            pacoteBanco.Inserir(pacote);
            ViewBag.Mensagem = "Cadastro realizado com sucesso";
            return View();
        }

        public IActionResult Editar(int id_pacotes){
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            PacoteBanco pacoteBanco = new PacoteBanco();
            Pacote pacote = pacoteBanco.BuscarPorId(id_pacotes);
            return View(pacote);
        }

        [HttpPost]
        public IActionResult Editar(Pacote pacote){
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            PacoteBanco pacoteBanco = new PacoteBanco();
            pacoteBanco.Atualizar(pacote);
            ViewBag.Mensagem = "Pacote atualizado";
            return RedirectToAction("Lista");
        }

        public IActionResult Remover(int id_pacotes){
             if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            PacoteBanco pacoteBanco = new PacoteBanco();
            pacoteBanco.Remover( id_pacotes);

            return RedirectToAction("Lista");
        }



        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario){
            UsuarioBanco usuarioBanco = new UsuarioBanco();
            Usuario usuarioSessao = usuarioBanco.ValidarLogin(usuario);

            if(usuario != null){
                ViewBag.Mensagem = "Você esta logado";
                HttpContext.Session.SetInt32("IdUsuario", usuarioSessao.Id);
                HttpContext.Session.SetString("NomeUsuario", usuarioSessao.Nome);

                return Redirect("Cadastro");
            }else{
                ViewBag.Mensagem = "Falha no Login";
                return View();
            }
        }

        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Usuario");
        }
    }
}