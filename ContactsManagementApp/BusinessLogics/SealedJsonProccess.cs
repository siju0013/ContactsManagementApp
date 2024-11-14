using ContactsManagementApp.Modals;
using Newtonsoft.Json;

namespace ContactsManagementApp.BusinessLogics
{
    public sealed  class SealedJsonProccess
    {
        public async Task<List<Contact>>? ReadAsync(string path)
        {
            string json = await File.ReadAllTextAsync(path);
            return (json != null&&json!=string.Empty) ? JsonConvert.DeserializeObject<List<Contact>>(json) : [];
        }
        public async Task<bool> WriteAsync(List<Contact> input, string path)
        {
            if (input == null)
            {
                return false;
            }
            else
            {
                string json=JsonConvert.SerializeObject(input);
                File.WriteAllTextAsync(path, json);
                return true;
            }
        }
    }
}
