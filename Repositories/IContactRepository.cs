using ControleDeContatos.Models;

namespace ControleDeContatos.Repository;

public interface IContactRepository
{
    ContactModel ListById(int id);
    List<ContactModel> GetAll();
    ContactModel Add(ContactModel contact);
    ContactModel Update(ContactModel contact);
    bool Delete(int id);
}