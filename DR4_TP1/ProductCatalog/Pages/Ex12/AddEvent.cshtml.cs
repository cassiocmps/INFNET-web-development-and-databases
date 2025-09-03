using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ProductCatalog.Pages.Ex12
{
    public class AddEventModel : PageModel
    {
        [BindProperty]
        public string EventTitle { get; set; }
        [BindProperty]
        public DateTime EventDate { get; set; }
        [BindProperty]
        public string EventLocation { get; set; }
        public bool ShowResult { get; set; }

        public static Action<Event> OnEventCreated = e => Console.WriteLine($"Event created: {e.Title}, {e.Date:yyyy-MM-dd}, {e.Location}");

        public void OnGet()
        {
            ShowResult = false;
        }

        public void OnPost()
        {
            ShowResult = true;
            var newEvent = new Event
            {
                Title = EventTitle,
                Date = EventDate,
                Location = EventLocation
            };
            OnEventCreated?.Invoke(newEvent);
        }
    }
}
