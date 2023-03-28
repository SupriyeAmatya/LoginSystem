using Login.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MBNOfficeSystem.Data
{
    public class ApplicationUserStore : UserStore<AppUser>
    {
        public ApplicationUserStore(DbContext context)
            : base(context) { }
    }
}
