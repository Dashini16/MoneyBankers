using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyBankers.Data;
using MoneyBankers.Models;

namespace MoneyBankers.Pages.Payment
{
    public class CreateModel : PageModel
    {
        private readonly MoneyBankers.Data.MoneyBankersContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CreateModel(MoneyBankers.Data.MoneyBankersContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Payment Payment { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string userName = _userManager.GetUserName(User);
            ApplicationUser sender = _context.Users.SingleOrDefault(u=>u.Email==userName);
            ApplicationUser receiver = _context.Users.SingleOrDefault(u => u.Email == Payment.Receiver);
            if (receiver != null)
            {
                if (sender.BankBalance < Payment.Amount || sender.BankBalance <= 0)
                {
                    TempData["message"] = "Low bank balance";
                }
                else
                {
                    receiver.BankBalance = receiver.BankBalance + Payment.Amount;
                    sender.BankBalance = sender.BankBalance - Payment.Amount;
                    Payment.Sender = userName;
                    _context.Payment.Add(Payment);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
            }
            else
            {
                TempData["message"] = "No such receipient";
            }
            return Page();
        }
    }
}
