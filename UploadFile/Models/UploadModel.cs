using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadFile.Models
{
    public class UploadModel
    {
        public string Title { get; set; }

        public IFormFile File { get; set; }
    }
}
