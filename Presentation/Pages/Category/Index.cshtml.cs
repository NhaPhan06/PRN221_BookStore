using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.DataAccess;

namespace Presentation.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.PRN_BookStoreContext _context;

        public IndexModel(DataAccess.PRN_BookStoreContext context)
        {
            _context = context;
        }

        public IList<DataAccess.DataAccess.Category> Category { get;set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Category = await _context.Categories.ToListAsync();
            }
        }
    }
}
