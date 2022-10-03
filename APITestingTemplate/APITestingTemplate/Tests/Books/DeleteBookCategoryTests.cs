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
    public class DeleteBookCategoryTests : ApiTestsBase, IClassFixture<AddBookCategoryFixture>
    {
        private readonly AddBookCategoryFixture _addBookCategoryFixture;
        public DeleteBookCategoryTests(AddBookCategoryFixture addBookCategoryFixture)
        {
            _addBookCategoryFixture = addBookCategoryFixture;
        }
        
        [Trait("Category", "Delete Book Categories")]
        [Fact]
        public void Scenario_1_As_a_user_I_can_delete_a_book_category_by_its_Id()
        {
            var bookCategoryData = _addBookCategoryFixture.BookCategoryData;
            var bookCategoryId = bookCategoryData.Id;

            var deleteBookCategoryResponse = Delete<BookCommandResult>(bookCategoryId, Resources.BookCategory);

            deleteBookCategoryResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getBookCategoryResponse = Get<GetBookCategoryDtoCommandResult>(bookCategoryId, Resources.BookCategory);

            getBookCategoryResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


    }
}
