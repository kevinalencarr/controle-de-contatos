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


    public ContactModel ListById(int id)
    {
        return _dataContext.Contacts.FirstOrDefault(x => x.Id == id);
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

    public ContactModel Update(ContactModel contact)
    {
        ContactModel contactDB = ListById(contact.Id);

        if (contactDB == null) throw new Exception("Nenhum contato encontrado.");

        contactDB.Name = contact.Name;
        contactDB.Email = contact.Email;
        contactDB.Phone = contact.Phone;

        _dataContext.Contacts.Update(contactDB);
        _dataContext.SaveChanges();

        return contactDB;
    }

    public bool Delete(int id)
    {
        ContactModel contactDB = ListById(id);

        if (contactDB == null) throw new Exception("Nenhum contato encontrado.");

        _dataContext.Contacts.Remove(contactDB);
        _dataContext.SaveChanges();

        return true;
    }
}