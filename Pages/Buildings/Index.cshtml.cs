using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RezerwacjeSalAB.Data;
using RezerwacjeSalAB.Models;

namespace RezerwacjeSalAB.Pages.Buildings
{
    public class IndexModel : PageModel
    {
        private readonly RezerwacjeSalAB.Data.ApplicationDbContext _context;

        public IndexModel(RezerwacjeSalAB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Building> Building { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Buildings != null)
            {
                Building = await _context.Buildings.ToListAsync();
            }
        }
    }
}
