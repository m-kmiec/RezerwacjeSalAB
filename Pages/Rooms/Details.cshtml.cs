using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RezerwacjeSalAB.Data;
using RezerwacjeSalAB.Models;

namespace RezerwacjeSalAB.Pages.Rooms
{
    public class DetailsModel : PageModel
    {
        private readonly RezerwacjeSalAB.Data.ApplicationDbContext _context;

        public DetailsModel(RezerwacjeSalAB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Room Room { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }
            else 
            {
                Room = room;
            }
            return Page();
        }
    }
}
