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
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.DataAccess.PRN_BookStoreContext _context;

        public DetailsModel(DataAccess.DataAccess.PRN_BookStoreContext context)
        {
            _context = context;
        }

      public DataAccess.DataAccess.UserDetail UserDetail { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.UserDetails == null)
            {
                return NotFound();
            }

            var userdetail = await _context.UserDetails.FirstOrDefaultAsync(m => m.UserDetailId == id);
            if (userdetail == null)
            {
                return NotFound();
            }
            else 
            {
                UserDetail = userdetail;
            }
            return Page();
        }
    }
}
