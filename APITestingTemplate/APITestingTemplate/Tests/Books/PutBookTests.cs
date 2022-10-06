using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audacia.Testing.Api;
using System.Net;
using APITestingTemplate.Fixtures;
using APITestingTemplate.Helpers;
using APITestingTemplate.Models.Dtos;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;

namespace APITestingTemplate.Tests.Academy
{
    public class PutBookTests : ApiTestsBase, IClassFixture<AddBookAndCategoryFixture>
    {
        private Random RandomBook { get; } = new Random();

        private readonly BookAndCategoryHelper _bookHelper;

        private readonly AddBookAndCategoryFixture _addBookAndCategoryFixture;

        public PutBookTests(AddBookAndCategoryFixture addBookAndCategoryFixture)
        {
            _addBookAndCategoryFixture = addBookAndCategoryFixture;
            _bookHelper = new BookAndCategoryHelper();
        }
    

    [Fact]
        public void Scenario_1_As_a_user_I_can_update_a_book()
        {
            /* Create a new book category and book to update using the fixtures */
            var bookCategoryData = _addBookAndCategoryFixture.BookData.BookCategoryData;
            var bookCategoryId = bookCategoryData.First().Id;
            var bookData = _addBookAndCategoryFixture.BookData.BookData;
            var bookId = bookData.First().Id;

            /* Setting up the request body for updating a book */
            var updateBookRequest = SetupWithoutSave<UpdateBookRequest>();
            
            updateBookRequest.Id = bookId;
            updateBookRequest.Randomise(bookCategoryId);

            /* Call the get API to update given book with above details */
            var updateBookResponse = Put<GetBookDtoCommandResult>(updateBookRequest, Resources.UpdateBook);

            /* Check the status code is ok */
            updateBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            
            /* Call the get API to get the book by its ID */
            var getBookResponse = Get<GetBookDtoCommandResult>(bookId, Resources.GetBookById);

            /* Check the status code is OK */
            getBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            /* Check the book has been updated to given values */
            getBookResponse.Data.Output.Title.Should().Be(updateBookRequest.Title);
            getBookResponse.Data.Output.Description.Should().Be(updateBookRequest.Description); 
            getBookResponse.Data.Output.Author.Should().Be(updateBookRequest.Author);   
            getBookResponse.Data.Output.PublishedYear.Should().Be(updateBookRequest.PublishedYear);
        }

        [Fact]
        public void Scenario_2_As_a_user_I_cannot_update_a_book_with_nullified_fields()
        {
            // Create a new book category and book to update using the fixtures
            var bookCategoryData = _addBookAndCategoryFixture.BookData.BookCategoryData;
            var bookCategoryId = bookCategoryData.First().Id;
            var bookData = _addBookAndCategoryFixture.BookData.BookData;
            var bookId = bookData.First().Id;

            // Setting up the request body for updating a book
            var updateBookRequest = SetupWithoutSave<UpdateBookRequest>();

            // Reassign new random values to book data fields
            updateBookRequest.Id = bookId;
            updateBookRequest.Randomise(bookCategoryId);

            // Reassign some fields to null
            updateBookRequest.Title = null;
            updateBookRequest.PublishedYear = null;

            //updateBookRequest.Id = bookId;
            //updateBookRequest.Description = "If you're a dinosaur, all of your friends are dead. If you're a pirate, all of your friends have scurvy. If you're a tree, all of your friends are end tables.";
            //updateBookRequest.Author = "Avery Monsen, Jory John";
            //updateBookRequest.AvailableFrom = DateTimeOffset.Now;
            //updateBookRequest.BookCategoryId = 13;
            //updateBookRequest.HasEBook = true;

            // Call the get API to update given book with above details
            var updateBookResponse = Put<UpdateBookRequest>(updateBookRequest, Resources.UpdateBook);

            // Check the status code is ok
            updateBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            /* Call the get API to get the book by its ID */
            var getBookResponse = Get<GetBookDtoCommandResult>(bookId, Resources.GetBookById);

            /* Check the status code is OK */
            getBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            /* Check the book has not been updated and still has original values */
            getBookResponse.Data.Output.Title.Should().Be(bookData.First().Title);
            getBookResponse.Data.Output.Description.Should().Be(bookData.First().Description);
        }
    }
}
