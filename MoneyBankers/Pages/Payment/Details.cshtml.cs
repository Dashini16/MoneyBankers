using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoneyBankers.Data;
using MoneyBankers.Models;

namespace MoneyBankers.Pages.Payment
{
    public class DetailsModel : PageModel
    {
        private readonly MoneyBankers.Data.MoneyBankersContext _context;

        public DetailsModel(MoneyBankers.Data.MoneyBankersContext context)
        {
            _context = context;
        }

        public Models.Payment Payment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Payment = await _context.Payment.FirstOrDefaultAsync(m => m.ID == id);

            if (Payment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
