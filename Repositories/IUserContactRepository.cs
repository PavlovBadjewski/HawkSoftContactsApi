using HawkSoftContactsApi.Models;
using System.Threading.Tasks;

namespace HawkSoftContactsApi.Repositories
{
    public interface IUserContactRepository
    {
        Task<PaginatedUserContacts> RetrievePaginatedUserContacts(int page, int limit);

        int AddUserContact(UserContact contact);

        int EditUserContact(int id, UserContact contact);

        int DeleteUserContact(int id);
    }
}