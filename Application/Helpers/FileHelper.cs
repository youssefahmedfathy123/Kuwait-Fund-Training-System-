using Microsoft.AspNetCore.Http;
using System.IO;



namespace Application.Helpers
{
    public static class FileHelper
    {
        public static byte[] ConvertToBytes(IFormFile file)
        {
            using var ms = new MemoryStream();
            file.CopyTo(ms);
            return ms.ToArray();
        }
    }

}


//return File(document.FileData, document.ContentType, $"{document.Title}.pdf");

