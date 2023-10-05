using HistorySpot.Data;
using HistorySpot.Models;
using HistorySpot.Models.ViewModels;
using HistorySpot.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HistorySpot.Controllers
{


    public class HistoricalPointController : Controller
    {
        private readonly IHistoricalPointRepository historicalPointRepository;
        private readonly ILikeRepository likeRepository;

        public ILikeRepository LikeRepository { get; set; }

        public HistoricalPointController (IHistoricalPointRepository historicalPointRepository,
            ILikeRepository likeRepository)
        {
            this.historicalPointRepository = historicalPointRepository;
            this .likeRepository = likeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
            var historicalPointId = await likeRepository.GetByUrlHandleAsync(urlHandle);
            var historicalDetailsViewModel = new HistoricalDetailsViewModel();

            if (historicalPointId != null)
            {
                var totalLikes = await likeRepository.GetTotalLikes(historicalDetailsViewModel.Id);

                historicalDetailsViewModel = new HistoricalDetailsViewModel
                {
                    Id = historicalDetailsViewModel.Id,
                    Name = historicalDetailsViewModel.Name,
                    Description = historicalDetailsViewModel.Description,
                    Latitude = historicalDetailsViewModel.Latitude,
                    Longitude = historicalDetailsViewModel.Longitude,
                    ImageUrl = historicalDetailsViewModel.ImageUrl,
                    Date = historicalDetailsViewModel.Date,
                    TotalLikes = totalLikes
                };


            }
            return View(historicalDetailsViewModel);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddHistoricalPointRequest addHistoricalPointRequest)
        {
            var historicalPoint = new HistoricalPoint
            {
                Name = addHistoricalPointRequest.Name,
                Description = addHistoricalPointRequest.Description,
                Latitude = addHistoricalPointRequest.Latitude,
                Longitude = addHistoricalPointRequest.Longitude,
                Date = addHistoricalPointRequest.Date
            };
            await historicalPointRepository.AddAsync(historicalPoint);

            return View("Add");
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var historicalPoint = await historicalPointRepository.GetAllAsync();

            return View(historicalPoint);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(EditHistoricalPointRequest editHistoricalPointRequest)
        {
           var deletedHistoricalPoint = await historicalPointRepository.DeleteAsync(editHistoricalPointRequest.Id);
            if(deletedHistoricalPoint != null)
            {
                // Show success 
                return RedirectToAction("List");
            }
            else
            {
                // Show Error 
                return RedirectToAction("Edit", new { id = editHistoricalPointRequest.Id });

            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var historicalPoint = await historicalPointRepository.GetAsync(id);

            if (historicalPoint != null)
            {
                var editHistoricalPointRequest = new EditHistoricalPointRequest
                {
                    Id = historicalPoint.Id,
                    Name = historicalPoint.Name,
                    Description = historicalPoint.Description,
                    Latitude = historicalPoint.Latitude,
                    Longitude = historicalPoint.Longitude,
                    ImageUrl = historicalPoint.ImageUrl,
                    Date = historicalPoint.Date,
                };
                return View(editHistoricalPointRequest);
            }
            return View(null);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditHistoricalPointRequest editHistoricalPointRequest)
        {
            var historicalPoint = new HistoricalPoint
            {
                Id = editHistoricalPointRequest.Id,
                Name = editHistoricalPointRequest.Name,
                Description = editHistoricalPointRequest.Description,
                Latitude = editHistoricalPointRequest.Latitude,
                Longitude = editHistoricalPointRequest.Longitude,
                ImageUrl = editHistoricalPointRequest.ImageUrl,
                Date = editHistoricalPointRequest.Date

            };
            var updatedHistoricalPoint = await historicalPointRepository.UpdateAsync(historicalPoint);
            if (updatedHistoricalPoint != null)
            {
                // Show Success 
            }
            else
            {
                // Show error
            }
             return RedirectToAction("Edit", new { id = editHistoricalPointRequest.Id });
        }
    }
}
