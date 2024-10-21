using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using EstudiesDocker.Data;
using EstudiesDocker.Entites.Vehicle;
using Microsoft.AspNetCore.Mvc;
using EstudiesDocker.Strategi;

namespace EstudiesDocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _acessor;
        private readonly IPaymentStrategyContext _paymentStrategy;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;


        public WeatherForecastController(DataContext context, IConfiguration configuration, IHttpContextAccessor acessor, IPaymentStrategyContext paymentStrategy)
        {
            _context = context;
            _configuration = configuration;
            _acessor = acessor;
            _paymentStrategy = paymentStrategy;
        }

        [HttpGet("GetWeatherForecast/{name}")]
        public IEnumerable<WeatherForecast> Get([FromRoute]string name)
        {
            try
            {
                var guid = Guid.NewGuid();
                _context.Add(VehicleManual.Factories.VehicleManual(guid, "testeDocker", "ss", "RONDO"));
                _context.SaveChanges();

                var result = _context.Vehicles.Find(guid);

                if (result is VehicleManual vehicleManual)
                    vehicleManual.Cancel();
                if (result is VehiclePlanned planned)
                    planned.SetDate();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message ?? "empty");
            }
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("User/{userId}/Upload-Pdf")]
        public async Task<IActionResult> UploadPdf([FromRoute] Guid userId,  IFormFile file, CancellationToken ct = default)
        {

            var connString = _configuration["BlobConnection:Blob"];
            var containerName = _configuration["BlobConnection:BlobPDF"];
        
            var blobServiceClient = new BlobServiceClient(connString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync(PublicAccessType.BlobContainer, cancellationToken: ct);

            var blobName = $"{userId}.pdf";

            var blobClient = containerClient.GetBlobClient(blobName);

       
            await using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, true, ct);
            }

            var user = _context.Vehicles.Find(userId);
            var blobUrl = blobClient.Uri.ToString();
            user.AddLinkPhoto(blobUrl);
            user.AddFileName(blobName);
            await _context.SaveChangesAsync();

           
            return Ok(blobUrl);
        }
        [HttpGet("User/{userId}/Download-Image")]
        public async Task DownloadImageAsync([FromRoute] Guid userId)
        {
            _paymentStrategy.SetStrategy(new PaymentCreditCard());
            _paymentStrategy.Payment(33.33m);
            var t = HttpContext.GetRouteData();

            var connString = _configuration["BlobConnection:Blob"];
            var containerName = _configuration["BlobConnection:BlobPDF"];

            BlobServiceClient blobServiceClient = new BlobServiceClient(connString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

           var user =  _context.Vehicles.Find(userId);

            // Get a reference to the blob (file) you want to download
            var path = Path.Combine(Environment.CurrentDirectory, user!.FileName!);
            BlobClient blobClient = containerClient.GetBlobClient(user.FileName);

       
           
            // Download the file
            BlobDownloadInfo download = await blobClient.DownloadAsync();

            using (MemoryStream ms = new MemoryStream())
            {
                // Copiar o conteúdo do blob para o MemoryStream
                await download.Content.CopyToAsync(ms);
                byte[] fileBytes = ms.ToArray();

                // Salvar os bytes em um arquivo local
                System.IO.File.WriteAllBytes(path, fileBytes);

                Console.WriteLine($"Arquivo baixado e salvo em: {path}");

            }

        }

       


    }
}
