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
            Messages = new List<Message>();
        }
        public IActionResult OnPostDeleteAllMessagesAsync()
        {
            //await _db.DeleteAllMessagesAsync();

            return RedirectToPage();
        }
    }
}
