using Microsoft.AspNetCore.Mvc;
using AbcRetail.Models;
using AbcRetail.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AbcRetail.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlobService _blobService;
        private readonly TableService _tableService;
        private readonly QueueService _queueService;
        private readonly FileService _fileService;

        // Constructor to inject required services for interacting with Azure Storage
        public HomeController(BlobService blobService, TableService tableService, QueueService queueService, FileService fileService)
        {
            _blobService = blobService;
            _tableService = tableService;
            _queueService = queueService;
            _fileService = fileService;
        }

        // Action to render the home page
        public IActionResult Index()
        {
            return View();
        }

        // Action to handle image uploads to Azure Blob Storage
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file != null)
            {
                using var stream = file.OpenReadStream();
                // Uploads the image to a predefined Blob container in Azure
                await _blobService.UploadBlobAsync("product-images", file.FileName, stream);
            }
            return RedirectToAction("Index");
        }

        // Action to add a customer profile to Azure Table Storage
        [HttpPost]
        public async Task<IActionResult> AddCustomerProfile(CustomerProfile profile)
        {
            if (ModelState.IsValid)
            {
                // Adds the customer profile entity to the Table Storage
                await _tableService.AddEntityAsync(profile);
            }
            return RedirectToAction("Index");
        }

        // Action to process an order by sending a message to Azure Queue Storage
        [HttpPost]
        public async Task<IActionResult> ProcessOrder(string orderId)
        {
            // Sends a message with the order ID to a predefined Azure Queue
            await _queueService.SendMessageAsync("order-processing", $"Processing order {orderId}");
            return RedirectToAction("Index");
        }

        // Action to upload contract files to Azure File Storage
        [HttpPost]
        public async Task<IActionResult> UploadContract(IFormFile file)
        {
            if (file != null)
            {
                using var stream = file.OpenReadStream();
                // Uploads the contract file to a predefined File Share in Azure
                await _fileService.UploadFileAsync("contracts-logs", file.FileName, stream);
            }
            return RedirectToAction("Index");
        }
    }
}

