using ContactsManagementApp.Modals;
using System.Text.Json;

namespace ContactsManagementApp.DataServices
{
    public class DataService
    {
        public List<Contact> Contacts { get; set; } = [];

        public async Task LoadData(string path)
        {
            string json = await File.ReadAllTextAsync(path);
            Contacts = JsonSerializer.Deserialize<List<Contact>>(json)!;
        }

    }
}
