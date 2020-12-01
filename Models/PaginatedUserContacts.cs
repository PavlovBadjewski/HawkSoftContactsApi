using System.Collections.Generic;

namespace HawkSoftContactsApi.Models
{
    public class PaginatedUserContacts
    {
        public int TotalCount { get; set; }

        public IList<UserContact> Contacts { get; set; }
    }
}