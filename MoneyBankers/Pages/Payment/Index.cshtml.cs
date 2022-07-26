using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneyBankers.Data;
using MoneyBankers.Models;

namespace MoneyBankers.Pages.Payment
{
    public class IndexModel : PageModel
    {
        private readonly MoneyBankers.Data.MoneyBankersContext _context;

        public IndexModel(MoneyBankers.Data.MoneyBankersContext context)
        {
            _context = context;
        }

        public IList<Models.Payment> Payment { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public string SQLmessage { get; set; }
        public async Task OnGetAsync(String SearchString)
        {

            SQLmessage = "Select * From Payment Where Sender Like '%" + SearchString + "%'";
            Payment = await _context.Payment.FromSqlRaw(SQLmessage).ToListAsync();
            TempData["message"] = "Entered SQL :" + SQLmessage;


        }
        public async Task<IActionResult> OnPostAsync(String SearchString)
        {
            return RedirectToPage("./Index");
        }
    }
}
