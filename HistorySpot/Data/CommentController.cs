using Microsoft.AspNetCore.Mvc;

namespace HistorySpot.Data
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
