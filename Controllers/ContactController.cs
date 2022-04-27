using ControleDeContatos.Models;
using ControleDeContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            List<ContactModel> contacts = _contactRepository.GetAll();

            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }

        public IActionResult DeleteConfirm(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _contactRepository.Delete(id);
                if (deleted)
                {
                    TempData["SuccessMessage"] = "Contato deletado com sucesso.";
                }
                else
                {
                    TempData["ErrorMessage"] = $"Ops! Algo deu errado.";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception error)
            {
                TempData["ErrorMessage"] = $@"Ops! Algo deu errado.
                    Detalhes do erro: {error.Message}.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Add(contact);
                    TempData["SuccessMessage"] = "Contato cadastrado com sucesso.";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (System.Exception error)
            {
                TempData["ErrorMessage"] = $@"Ops! Algo deu errado.
                    Detalhes do erro: {error.Message}.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Update(contact);
                    TempData["SuccessMessage"] = "Contato editado com sucesso.";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (System.Exception error)
            {
                TempData["ErrorMessage"] = $@"Ops! Algo deu errado.
                    Detalhes do erro: {error.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}