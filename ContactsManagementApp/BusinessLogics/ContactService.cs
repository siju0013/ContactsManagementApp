using ContactsManagementApp.DataServices;
using ContactsManagementApp.Modals;

namespace ContactsManagementApp.BusinessLogics
{
    public class ContactService: IContactService
    {
        private readonly SealedJsonProccess _process;
        private readonly DataService _dataService;
        public ContactService(DataService dataService)
        {
            _process = new SealedJsonProccess();
            _dataService = dataService;
        }
        public List<Contact> GetContacts(string path)
        {
            return _dataService.Contacts;

        }

        public async Task<List<Contact>> Create(ContactObj contact, string path)
        {
            if (contact != null)
            {
                Contact Obj = new Contact { Id = _dataService.Contacts.Max(x => x.Id) + 1, FirstName = contact.FirstName, LastName = contact.LastName, Email = contact.Email };
                _dataService.Contacts.Add(Obj);
            }

            await _process.WriteAsync(_dataService.Contacts, path);
            return _dataService.Contacts;

        }
        public async Task<List<Contact>> Modify(int ID, ContactObj input, string path)
        {
            var obj = _dataService.Contacts.Find(x => x.Id == ID);
            if (obj is null) return _dataService.Contacts;
            obj.FirstName = input.FirstName;
            obj.LastName = input.LastName;
            obj.Email = input.Email;
            await _process.WriteAsync(_dataService.Contacts, path);
            return _dataService.Contacts;

        }
        public async Task<List<Contact>> Delete(string path,int ID)
        {
            var obj = _dataService.Contacts.Find(x => x.Id == ID);
            if (obj is null) return _dataService.Contacts;
            _dataService.Contacts.Remove(obj);
            await _process.WriteAsync(_dataService.Contacts, path);
            return _dataService.Contacts;

        }

    }
}
