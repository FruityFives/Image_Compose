using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;

namespace minServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private string _imagePath = string.Empty;
        private readonly ILogger<ImageController> _logger;

        public ImageController(ILogger<ImageController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _imagePath = configuration["ImagePath"] ?? string.Empty;
        }

        [HttpGet("listImages")]
        public IActionResult ListImages()
        {
            List<Uri> images = new List<Uri>();

            if (Directory.Exists(_imagePath))
            {
                string[] fileEntries = Directory.GetFiles(_imagePath);
                foreach (var file in fileEntries)
                {
                    var imageURI = new Uri(file, UriKind.RelativeOrAbsolute);
                    images.Add(imageURI);
                }
            }
            return/*  */ Ok(images);
        }
    }
}
