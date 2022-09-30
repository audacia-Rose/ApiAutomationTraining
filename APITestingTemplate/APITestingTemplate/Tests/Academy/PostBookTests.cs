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

namespace APITestingTemplate.Tests.Academy
{
    public class PostBookTests : ApiTestsBase, IClassFixture<AddBookCategoryFixture>
    {
        private Random RandomBook { get;  } = new Random();

        private readonly AddBookCategoryFixture _addBookCategoryFixture;

        private readonly BookHelper _bookHelper;

        public PostBookTests(AddBookCategoryFixture addBookCategoryFixture)
        {
            _addBookCategoryFixture = addBookCategoryFixture;
            _bookHelper = new BookHelper();
        }

        [Trait("Category", "Add Books")]
        [Fact]
        public void Scenario_1_As_a_user_I_can_add_a_new_book()
        {
            // Create new book category using fixture & capture its ID
            var bookCategoryData = _addBookCategoryFixture.BookCategoryData;
            var bookCategoryId = bookCategoryData.Id;
            
            // Setting up the request body for a new book using our base customisation
            var addBookRequest = SetupWithoutSave<AddBookRequest>();

            // Base customisation sets book category to 1 so we can override this with the book category we've created
            addBookRequest.BookCategoryId = bookCategoryId;
                
            // Call the get API to add the new book with details provided in base customisation
            var addBookResponse = Post<GetBookDtoCommandResult>(addBookRequest, Resources.AddBook, null);

            // Check the status code is 201: created
            addBookResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            // Check new book has been added with given data
            addBookResponse.Data.Output.Title.Should().Be(addBookRequest.Title);
            addBookResponse.Data.Output.Description.Should().Be(addBookRequest.Description);

            // save the book ID in a variable so we can delete it (and its category) with the book helper
            var bookId = addBookResponse.Data.Output.Id;
            _bookHelper.DeleteBook(bookId);
        }

        [Trait("Category", "Add Books")]
        [Fact]
        public void Scenario_2_As_a_user_I_cannot_add_a_new_book_with_nullified_title()
        {
            // Create new book category using fixture & capture its ID
            var bookCategoryData = _addBookCategoryFixture.BookCategoryData;
            var bookCategoryId = bookCategoryData.Id;

            // Setting up the request body for a new book using our base customisation
            var addBookRequest = SetupWithoutSave<AddBookRequest>();

            // Base customisation sets book category to 1 so we can override this with the book category we've created
            addBookRequest.BookCategoryId = bookCategoryId;

            // Override the base customisation to set title to null
            addBookRequest.Title = null;

            // Call the get API to add the new book to system
            var addBookResponse = Post<GetBookDtoCommandResult>(addBookRequest, Resources.AddBook);

            // Check the status code is 400: bad request
            addBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Trait("Category", "Add Books")]
        [Fact] public void Scenario_3_As_a_user_I_cannot_add_a_new_book_with_book_category_that_does_not_exist()
        {
            // Setting up the request body for adding a new book
            var addBookRequest = SetupWithoutSave<AddBookRequest>();

            // Override book category with one that doesn't exist
            addBookRequest.BookCategoryId = 10;

            // Call the get API to add the new book to system
            var addBookResponse = Post<GetBookDtoCommandResult>(addBookRequest, Resources.AddBook);

            // Check the status code is 400: bad request
            addBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Trait("Category", "Add Books")]
        [Fact]
        public void Scenario_4_As_a_user_I_cannot_add_a_new_book_with_no_request_body()
        {
            // Setting up the request body for adding a new book
            var addBookRequest = new AddBookRequest();

            // Call the get API to add the new book to system
            var addBookResponse = Post<GetBookDtoCommandResult>(addBookRequest, Resources.AddBook);

            // Check the status code is 400: bad request
            addBookResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            /* This test created the book and set default
               values for the book's details */
        }


    }

}