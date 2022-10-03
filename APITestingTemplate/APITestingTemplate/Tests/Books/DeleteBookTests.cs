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
    public class DeleteBookTests : ApiTestsBase, IClassFixture<AddBookAndCategoryFixture>
    {
        private readonly AddBookAndCategoryFixture _addBookAndCategoryFixture;
        public DeleteBookTests(AddBookAndCategoryFixture addBookAndCategoryFixture)
        {
            _addBookAndCategoryFixture = addBookAndCategoryFixture;
        }
        
        [Trait("Category", "Delete Books")]
        [Fact]
        public void Scenario_1_As_a_user_I_can_delete_a_book_and_category_by_its_Id()
        {
            // Create a new book category and book to delete using the fixtures
            var bookCategoryData = _addBookAndCategoryFixture.BookData.BookCategoryData;
            var bookCategoryId = bookCategoryData.First().Id;
            var bookData = _addBookAndCategoryFixture.BookData.BookData;
            var bookId = bookData.First().Id;

            // Call the delete API to delete the book by its ID
            var deleteBookResponse = Delete<BookCommandResult>(bookId, Resources.GetBookById);

            // Check the status code is ok
            deleteBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Call the delete API to delete the book category by its ID
            var deleteBookCatResponse = Delete<BookCommandResult>(bookCategoryId, Resources.BookCategory);

            // Check status code is OK for deleting book category
            deleteBookCatResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Call the get API to get the book by its ID
            var getBookResponse = Get<GetBookDtoCommandResult>(bookId, Resources.GetBookById);

            // Check the status code is 'Bad Request' and it cannot find book
            getBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Call API to get book category by its ID
            var getBookCatResponse = Get<GetBookCategoryDtoCommandResult>(bookCategoryId, Resources.BookCategory);

            // Check API cannot find book category after its deletion
            getBookCatResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
