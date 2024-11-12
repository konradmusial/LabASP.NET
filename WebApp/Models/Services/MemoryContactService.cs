namespace WebApp.Models.Services;

public class MemoryContactService: IContactService
{
    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1, new ContactModel()
            {
                Id = 1,
                FirstName = "Jaroslaw",
                LastName = "Kaczynski",
                Category = Category.Friend,
                Email = "jarekpis@wp.pl",
                PhoneNumber = "123 123 213",
                BirthDate = new DateOnly(year: 1949, month: 6, day:18)

            }
        },
        {
            2, new ContactModel()
            {
                Id = 1,
                FirstName = "Jakub",
                LastName = "Nowak",
                Category = Category.Business,
                Email = "asghjghjd@ashgjghjd",
                PhoneNumber = "155 153 255",
                BirthDate = new DateOnly(year: 1999, month: 12, day: 13)

            }
        }
    };
    private static int _currentId = 3;
    
    public void Add(ContactModel model)
    {
        model.Id = ++_currentId;
        _contacts.Add(model.Id, model);
    }

    public void Update(ContactModel contact)
    {
        if (_contacts.ContainsKey(contact.Id))
        {
            _contacts[contact.Id] = contact;
        }
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        return _contacts[id];
    }
}