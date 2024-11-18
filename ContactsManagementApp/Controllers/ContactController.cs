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
        [HttpGet("GetAllContact")]
        public IActionResult GetAllContact()
        {
            var ContactList= _service.GetContacts(path);
            return Ok(ContactList);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateOrModify(ContactObj input)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _service.Create(input, path);
            return Ok(response);
        }
        [HttpPut("Modify/{ID}")]
        public async Task<IActionResult> Modify(int ID, ContactObj input)
        {
            
            if (ID == 0) {
                ModelState.AddModelError("ID", "Please select contact to be modified");
                return BadRequest(ModelState);
            }
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _service.Modify(ID,input, path);
            return Ok(response);
        }
        [HttpDelete("DeleteContact/{ID}")]
        public async Task<IActionResult> DeleteContact(int ID)
        {
            if (ID == 0)
            {
                ModelState.AddModelError("ID", "Please select contact to  delete");
                return BadRequest(ModelState);
            }
            var response = await _service.Delete(path,ID);
            return Ok(response);
        }

    }
}
