using HawkSoftContactsApi.Models;
using HawkSoftContactsApi.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HawkSoftContactsApi.Controllers
{
    [ApiController]
    [Route("/api/v1/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IUserContactHandler _userContactHandler;

        public ContactsController(IUserContactHandler userContactHandler)
        {
            _userContactHandler = userContactHandler;
        }

        [HttpGet]
        [Route("")]
        public async Task<PaginatedUserContacts> RetrievePaginatedUserContacts(int page, int limit)
        {
            return await _userContactHandler.RetrievePaginatedUserContacts(page, limit);
        }

        [HttpPost]
        [Route("")]
        public int AddUserContact([FromBody]UserContact contact)
        {
            return _userContactHandler.AddUserContact(contact);
        }

        [HttpPut]
        [Route("{contactId}")]
        public int EditUserContact(int contactId, [FromBody] UserContact contact)
        {
            return _userContactHandler.EditUserContact(contactId, contact);
        }

        [HttpDelete]
        [Route("{contactId}")]
        public int DeleteUserContact(int contactId)
        {
            return _userContactHandler.DeleteUserContact(contactId);
        }
    }
}
