using ContactsManagementApp.Modals;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace ContactsManagementApp.BusinessLogics
{
    public class ContactService: IContactService
    {
        private readonly SealedJsonProccess _process;
        public ContactService()
        {
            _process = new SealedJsonProccess();
        }
        public async Task<List<Contact>> readJsonFile(string path)
        {
            var res = await _process.ReadAsync(path);
            return res;
        }

        public async Task<List<Contact>> Create(ContactObj contact, string path)
        {
            var List = await _process.ReadAsync(path);
            if (contact != null)
            {
                Contact Obj=new Contact { FirstName=contact.FirstName, LastName=contact.LastName,Email=contact.Email };
                List.Add(Obj);
            }
          
            var res=await _process.WriteAsync(List, path);
            return List;
        }
        public async Task<List<Contact>> Modify(int ID, ContactObj input, string path)
        {
            var List = await _process.ReadAsync(path);

            var obj = List.Where(x => x.Id == ID).FirstOrDefault();
            obj.FirstName = input.FirstName;
            obj.LastName = input.LastName;
            obj.Email = input.Email;

            var res = await _process.WriteAsync(List, path);
            return List;
        }
        public async Task<List<Contact>> Delete(string path,int ID)
        {
            var List = await _process.ReadAsync(path);
            var obj = List.Where(x => x.Id == ID).FirstOrDefault();
            List.Remove(obj);
            var res = await _process.WriteAsync(List, path);
            return List;
        }
       
    }
}
