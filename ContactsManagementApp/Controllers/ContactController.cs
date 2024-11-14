using ContactsManagementApp.BusinessLogics;
using ContactsManagementApp.Modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly string path;
        private readonly IContactService _service; 
        public ContactController(IContactService service)
        {
            path= Path.Combine(Directory.GetCurrentDirectory(), "contact.json");
            _service = service;
        }
        [HttpGet("getAllContact")]
        public async Task<IActionResult> getAllContact()
        {
            var obj=await _service.readJsonFile(path);
            return Ok(obj);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateOrModify(ContactObj input)
        {
            var res = await _service.Create(input, path);
            return Ok(res);
        }
        [HttpPut("Modify/{ID}")]
        public async Task<IActionResult> CreateOrModify(int ID, ContactObj input)
        {
            var res = await _service.Modify(ID,input, path);
            return Ok(res);
        }
        [HttpDelete("DeleteContact/{ID}")]
        public async Task<IActionResult> DeleteContact(int ID)
        {
            var res = await _service.Delete(path,ID);
            return Ok(res);
        }

    }
}
