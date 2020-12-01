using System;
using System.Threading.Tasks;
using HawkSoftContactsApi.Models;
using HawkSoftContactsApi.Repositories;

namespace HawkSoftContactsApi.Handlers
{
    public class UserContactHandler: IUserContactHandler
    {
        private readonly IUserContactRepository _userContactRepository;

        public UserContactHandler(IUserContactRepository userContactRepository)
        {
            _userContactRepository = userContactRepository;
        }

        public async Task<PaginatedUserContacts> RetrievePaginatedUserContacts(int page, int limit)
        {
            return await _userContactRepository.RetrievePaginatedUserContacts(page, limit);
        }

        public int AddUserContact(UserContact contact)
        {
            return _userContactRepository.AddUserContact(contact);
        }

        public int EditUserContact(int id, UserContact contact)
        {
            return _userContactRepository.EditUserContact(id, contact);
        }

        public int DeleteUserContact(int id)
        {
            return _userContactRepository.DeleteUserContact(id);
        }
    }
}