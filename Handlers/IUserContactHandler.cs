using HawkSoftContactsApi.Models;
using System.Threading.Tasks;

namespace HawkSoftContactsApi.Handlers
{
    public interface IUserContactHandler
    {
        Task<PaginatedUserContacts> RetrievePaginatedUserContacts(int page, int limit);

        int AddUserContact(UserContact contact);

        int EditUserContact(int id, UserContact contact);

        int DeleteUserContact(int id);
    }
}