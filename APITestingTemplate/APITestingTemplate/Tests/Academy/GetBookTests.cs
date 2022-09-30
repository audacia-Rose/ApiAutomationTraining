using System.Collections.Generic;
using System.Linq;
using System.Net;
using APITestingTemplate.Fixtures;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.CombinedDTOs;
using APITestingTemplate.Models.Dtos;
using Audacia.Testing.Api;
using FluentAssertions;
using Xunit;

namespace APITestingTemplate.Tests.Academy
{
    public class GetBooksTests : ApiTestsBase, IClassFixture<AddBookAndCategoryFixture>
    {
        private readonly AddBookAndCategoryFixture _addBookAndCategoryFixture;

        public GetBooksTests(AddBookAndCategoryFixture addBookAndCategoryFixture)
        {
            _addBookAndCategoryFixture = addBookAndCategoryFixture;
        }

        [Fact]
        public void Scenario_1_As_a_user_I_can_get_a_book_by_its_Id()
        {
            /* Set up a new book and category with fixture and choose as the book ID & Category we wish to get */ 
            var bookDetails = _addBookAndCategoryFixture.BookData.BookData;
            var bookCategoryDetails = _addBookAndCategoryFixture.BookData.BookCategoryData;
            var bookId = bookDetails.First().Id;
            var bookCategoryId = bookCategoryDetails.First().Id;
            
            // Call the get API to get the book by its ID
            var getBookResponse = Get<GetBookDtoCommandResult>(bookId, Resources.GetBookById);

            // Check the status code is ok
            getBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Check the book data you are returning is the book that you have just added
            getBookResponse.Data.Output.Title.Should().Be(bookDetails.First().Title);
            getBookResponse.Data.Output.Description.Should().Be(bookDetails.First().Description);
            getBookResponse.Data.Output.Author.Should().Be(bookDetails.First().Author);
            getBookResponse.Data.Output.PublishedYear.Should().Be(bookDetails.First().PublishedYear);
            //getBookResponse.Data.Output.AvailableFrom.Should().Be(bookDetails.First().AvailableFrom);
            getBookResponse.Data.Output.HasEBook.Should().Be(bookDetails.First().HasEBook);
            getBookResponse.Data.Output.Id.Should().Be(bookId);
            getBookResponse.Data.Output.BookCategoryId.Should().Be(bookCategoryId);

        }

        [Fact]
        public void Scenario_2_As_a_user_I_can_get_all_books()
        {
            // Call the API to get all books
            var getBookResponse2 = GetAll<List<GetBookDtoCommandResult>>(Resources.GetAllBooks);

            // Check status code is OK 
            getBookResponse2.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public void Scenario_3_As_a_user_I_cannot_get_a_book_by_an_Id_that_does_not_exist()
        {
            // Set the bookId you wish to get
            var bookId = 3;

            // Call the get API to get the book by its ID
            var getBookResponse = Get<GetBookDtoCommandResult>(bookId, Resources.GetBookById);

            // Check the status code shows an error
            getBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


    }
}