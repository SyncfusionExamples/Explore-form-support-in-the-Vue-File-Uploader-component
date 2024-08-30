using Microsoft.AspNetCore.Mvc;

namespace SyncfusionUploaderServerSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(List<IFormFile> UploadFiles, string Name, string Email, string MobileNo, string FileNames, string Address)
        {
            //Save the details in database
            return Ok(new { Message = "Your details have been updated successfully, Thank you." });
        }
    }
}