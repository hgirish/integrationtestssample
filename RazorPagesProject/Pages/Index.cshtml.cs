using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public Message Message { get; set; }


        public IList<Message> Messages { get; private set; }
        public void OnGet()
        {
            Messages = new List<Message>
            {
                new Message
                {
                    Text = "Test Message",
                    Id =1
                }
            };
        }
        public async Task<IActionResult> OnPostDeleteMessageAsync(int id)
        {
            //await _db.DeleteMessageAsync(id);

            return RedirectToPage();
        }
        public IActionResult OnPostDeleteAllMessagesAsync()
        {
            //await _db.DeleteAllMessagesAsync();

            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostAddMessageAsync()
        {
            if (!ModelState.IsValid)
            {
                // Messages = await _db.GetMessagesAsync();
                Messages = new List<Message>();
                return Page();
            }

           // await _db.AddMessageAsync(Message);

            return RedirectToPage();
        }
    }
}
