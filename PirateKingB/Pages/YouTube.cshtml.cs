using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PirateKingB.Pages
{
    public class YouTubeModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "YouTube page, son!";
        }
    }
}