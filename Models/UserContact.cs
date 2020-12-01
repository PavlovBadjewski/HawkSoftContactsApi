using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HawkSoftContactsApi.Models
{
    [Table("Contact")]
    public class UserContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "INTEGER")]
        public int ContactId { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("username")]
        public string Username { get; set; }
    }
}