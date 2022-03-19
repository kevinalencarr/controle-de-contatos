using ControleDeContatos.Models;

namespace ControleDeContatos.Repository;

public interface IContactRepository
{
    List<ContactModel> GetAll();
    ContactModel Add(ContactModel contact);
}