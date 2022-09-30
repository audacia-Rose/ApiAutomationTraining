using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.CombinedDTOs;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;

namespace APITestingTemplate.Fixtures
{

    public class AddBookCategoryFixture : ApiTestsBase, IDisposable
    {
        public GetBookCategoryDto BookCategoryData { get; }

        public AddBookCategoryFixture()
        {
            using var bookCategoryHelper = new BookCategoryHelper();

            BookCategoryData = bookCategoryHelper.AddBookCategory();
        }

        public void Dispose()
        {
            using var bookCategoryHelper = new BookCategoryHelper();

            bookCategoryHelper.DeleteBookCategory(BookCategoryData.Id);
        }
    }
}
