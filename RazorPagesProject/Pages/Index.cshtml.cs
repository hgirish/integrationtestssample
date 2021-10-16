using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesProject.Data;
using RazorPagesProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IQuoteService _quoteService;
        private readonly ApplicationDbContext _db;

        public IndexModel(ILogger<IndexModel> logger, IQuoteService quoteService, ApplicationDbContext db)
        {
            _logger = logger;
            _quoteService = quoteService;
            _db = db;
        }

        [BindProperty]
        public Message Message { get; set; }

        [TempData]
        public string MessageAnalysisResult { get; set; }

        public string Quote { get; private set; }

        public IList<Message> Messages { get; private set; }
        public async Task OnGetAsync()
        {
            Messages = await _db.GetMessagesAsync();
            Quote = await _quoteService.GenerateQuote();
        }
        public async Task<IActionResult> OnPostDeleteMessageAsync(int id)
        {
            await _db.DeleteMessageAsync(id);

            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostDeleteAllMessagesAsync()
        {
            await _db.DeleteAllMessagesAsync();

            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostAddMessageAsync()
        {
            if (!ModelState.IsValid)
            {
                 Messages = await _db.GetMessagesAsync();
              
                return Page();
            }

            await _db.AddMessageAsync(Message);

            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostAnalyzeMessagesAsync()
        {
            Messages = await _db.GetMessagesAsync();
        
          
            if (Messages.Count == 0)
            {
                MessageAnalysisResult = "There are no messages to analyze.";
            }
            else
            {
                var wordCount = 0;

                foreach (var message in Messages)
                {
                    wordCount += message.Text.Split(' ').Length;
                }

                var avgWordCount = Decimal.Divide(wordCount, Messages.Count);
                MessageAnalysisResult = $"The average message length is {avgWordCount:0.##} words.";
            }

            return RedirectToPage();
        }
    }
}
