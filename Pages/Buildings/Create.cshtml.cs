using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RezerwacjeSalAB.Data;
using RezerwacjeSalAB.Models;

namespace RezerwacjeSalAB.Pages.Buildings
{
    public class CreateModel : PageModel
    {
        private readonly RezerwacjeSalAB.Data.ApplicationDbContext _context;

        public CreateModel(RezerwacjeSalAB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["rooms"] = new SelectList(_context.Rooms, "Id", "Name");
            return Page();
        }

        [BindProperty] public Building Building { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(List<int> roomIds)
        {
            if (!ModelState.IsValid || _context.Buildings == null || Building == null)
            {
                return Page();
            }

            foreach (var roomId in roomIds)
            {
                var room = _context.Rooms.Find(roomId);
                Building.Rooms.Add(room);
            }

            _context.Buildings.Add(Building);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}