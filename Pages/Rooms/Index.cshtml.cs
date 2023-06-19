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
    public class IndexModel : PageModel
    {
        private readonly RezerwacjeSalAB.Data.ApplicationDbContext _context;

        public IndexModel(RezerwacjeSalAB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Room> Room { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rooms != null)
            {
                Room = await _context.Rooms.ToListAsync();
            }
        }
    }
}
