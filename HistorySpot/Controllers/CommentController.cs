using HistorySpot.Data;
using HistorySpot.Models;
using HistorySpot.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HistorySpot.Controllers
{
    public class CommentController : Controller
    {

        private readonly HistorySpotDbContext historySpotDbContext;
        private readonly UserManager<IdentityUser> userManager;

        public CommentController(HistorySpotDbContext historySpotDbContextuserManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.historySpotDbContext = historySpotDbContext;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.DatePosted = DateTime.Now;
                comment.Name = userManager.GetUserId(User); // Hämta användarens ID från Identity

                historySpotDbContext.comments.Add(comment);
                await historySpotDbContext.SaveChangesAsync();

                return RedirectToAction("List", new { id = comment.CommentId });
            }

            return View(null);
        }

        public IActionResult AddComment(Guid historicalPoint)
        {
            return View();
        }
    }
}
