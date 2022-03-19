using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repository;

public class ContactRepository : IContactRepository
{
    private readonly DataContext _dataContext;

    public ContactRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<ContactModel> GetAll()
    {
        return _dataContext.Contacts.ToList();
    }

    public ContactModel Add(ContactModel contact)
    {
        _dataContext.Contacts.Add(contact);
        _dataContext.SaveChanges(); // comita no banco
        return contact;
    }
}