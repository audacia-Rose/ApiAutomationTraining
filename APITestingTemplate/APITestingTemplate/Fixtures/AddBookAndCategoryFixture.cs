using System;
using System.Linq;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.CombinedDTOs;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;

namespace APITestingTemplate.Fixtures
{
    public class AddBookAndCategoryFixture : ApiTestsBase, IDisposable
    {
        public AddBookAndCategory BookData { get; }

        public AddBookAndCategoryFixture()
        {
            using var bookHelper = new BookAndCategoryHelper();

            BookData = bookHelper.PostBookAndCategory();
        }

        public void Dispose()
        {
            using var bookHelper = new BookAndCategoryHelper();

            bookHelper.DeleteBookAndCategory(BookData.BookData.First().Id, BookData.BookCategoryData.First().Id);
        }
    }
}

