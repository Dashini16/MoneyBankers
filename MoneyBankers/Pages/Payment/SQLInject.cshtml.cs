using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoneyBankers.Models;
using System.ComponentModel.DataAnnotations;

namespace MoneyBankers.Pages.Payment
{
    public class SQLInjectModel : PageModel
    {
        private readonly MoneyBankers.Data.MoneyBankersContext _context;

        public SQLInjectModel(MoneyBankers.Data.MoneyBankersContext context)
        {
            _context = context;
        }

        public IList<Models.Payment> Payments { get; set; }
        public string SQLmessage { get; set; }

        //[RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Entered Text contain Invalid characters")]
        public string SearchString { get; set; }

        public async Task OnGetAsync(String SearchString)
        {

            SQLmessage = "Select * From Payment Where Sender Like '%" + SearchString + "%'";
            Payments = await _context.Payment.FromSqlRaw(SQLmessage).ToListAsync();
            TempData["message"] = "Entered SQL :" + SQLmessage;

          
        }


        public async Task<IActionResult> OnPostAsync(String SearchString)
        {
            return RedirectToPage("./Index");
        }
    }
}

