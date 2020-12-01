using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HawkSoftContactsApi.Models;

namespace HawkSoftContactsApi.Repositories
{
    public class UserContactRepository: IUserContactRepository
    {
        private readonly UserContactsContext _dbContext;
        private readonly ILogger<UserContactRepository> _logger;

        public UserContactRepository(UserContactsContext dbContext, ILogger<UserContactRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<PaginatedUserContacts> RetrievePaginatedUserContacts(int page, int limit)
        {
            var contacts = await _dbContext.Contacts
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();
            var totalCount = await _dbContext.Contacts.CountAsync();

            return new PaginatedUserContacts()
            {
                Contacts = contacts,
                TotalCount = totalCount
            };
        }

        public int AddUserContact(UserContact contact)
        {
            _dbContext.Contacts.Add(contact);

            try
            {
                return _dbContext.SaveChanges();
            } 
            catch (Exception ex)
            {
                _logger.LogError("An error occurred");
                throw ex;
            }
        }

        public int EditUserContact(int id, UserContact contact)
        {
            var currentContact = _dbContext.Contacts.Find(contact.ContactId);

            currentContact.Address = contact.Address;
            currentContact.Email = contact.Email;
            currentContact.FirstName = contact.FirstName;
            currentContact.LastName = contact.LastName;
            currentContact.Username = contact.Username;

            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred");
                throw ex;
            }
        }

        public int DeleteUserContact(int id)
        {
            var contact = _dbContext.Contacts.Find(id);
            _dbContext.Contacts.Remove(contact);

            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred");
                throw ex;
            }
        }
    }
}