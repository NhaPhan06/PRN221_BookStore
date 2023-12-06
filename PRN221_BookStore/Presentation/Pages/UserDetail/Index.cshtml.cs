using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.DataAccess;

namespace Presentation.Pages.UserDetail
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.DataAccess.PRN_BookStoreContext _context;

        public IndexModel(DataAccess.DataAccess.PRN_BookStoreContext context)
        {
            _context = context;
        }

        public IList<DataAccess.DataAccess.UserDetail> UserDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserDetails != null)
            {
                UserDetail = await _context.UserDetails
                .Include(u => u.User).ToListAsync();
            }
        }
    }
}
