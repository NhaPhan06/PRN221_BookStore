using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.DataAccess;

namespace Presentation.Pages.UserDetail
{
    public class EditModel : PageModel
    {
        private readonly DataAccess.DataAccess.PRN_BookStoreContext _context;

        public EditModel(DataAccess.DataAccess.PRN_BookStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DataAccess.DataAccess.UserDetail UserDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.UserDetails == null)
            {
                return NotFound();
            }

            var userdetail =  await _context.UserDetails.FirstOrDefaultAsync(m => m.UserDetailId == id);
            if (userdetail == null)
            {
                return NotFound();
            }
            UserDetail = userdetail;
           ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailExists(UserDetail.UserDetailId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserDetailExists(Guid id)
        {
          return (_context.UserDetails?.Any(e => e.UserDetailId == id)).GetValueOrDefault();
        }
    }
}
