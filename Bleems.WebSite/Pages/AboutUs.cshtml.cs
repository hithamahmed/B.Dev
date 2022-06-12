using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bleems.WebSite.Pages
{
    [Authorize(Roles ="Administrator")]
    public class AboutUsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
