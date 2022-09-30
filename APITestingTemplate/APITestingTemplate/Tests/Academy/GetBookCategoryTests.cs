using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using APITestingTemplate.Fixtures;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;
using FluentAssertions;
using Xunit;

namespace APITestingTemplate.Tests.Academy
{
    public class GetBookCategoryTests : ApiTestsBase, IClassFixture<AddBookCategoryFixture>
    {
        private readonly AddBookCategoryFixture _addBookCategoryFixture;

        public GetBookCategoryTests(AddBookCategoryFixture addBookCategoryFixture)
        {
            _addBookCategoryFixture = addBookCategoryFixture;
        }

        [Fact]
        public void Scenario_4_As_a_user_I_can_get_books_by_Category_Id()
        {
            // Create new book category using book category fixture
            var bookCategoryDetails = _addBookCategoryFixture.BookCategoryData;
            var bookCategoryId = bookCategoryDetails.Id.ToString();

            // Call the get API to get the books with specified category ID
            var getBookResponse = GetAll<GetBookDtoCommandResult>(Resources.GetBooksByCat(bookCategoryId));

            // Check the status code is ok
            getBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
