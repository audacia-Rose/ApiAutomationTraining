using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using APITestingTemplate.Models.Dtos;
using Audacia.Random.Extensions;

namespace APITestingTemplate.Helpers
{
    internal static class BookHelpers
    {
        public static UpdateBookRequest Randomise(this UpdateBookRequest updateBookRequest, int bookCategoryId)
        {
            var random = new Random();
            updateBookRequest.Title = random.Words(3);
            updateBookRequest.Description = random.Sentence();
            updateBookRequest.Author = random.Forename() + random.Surname();
            updateBookRequest.PublishedYear = random.Birthday().Year;
            updateBookRequest.AvailableFrom = random.Birthday();
            updateBookRequest.BookCategoryId = bookCategoryId;
            updateBookRequest.HasEBook = random.Boolean();

            return updateBookRequest;
        }
    }
}
