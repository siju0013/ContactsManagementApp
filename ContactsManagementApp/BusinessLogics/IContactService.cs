using ContactsManagementApp.Modals;

namespace ContactsManagementApp.BusinessLogics
{
    public interface IContactService
    {
        Task<List<Contact>> readJsonFile(string path);
        Task<List<Contact>> Create(ContactObj contact, string path);
        Task<List<Contact>> Modify(int ID, ContactObj input, string path);
        Task<List<Contact>> Delete(string path, int ID);
    }
}
