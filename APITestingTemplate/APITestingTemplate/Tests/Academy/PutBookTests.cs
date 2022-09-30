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
    public class PutBookTests : ApiTestsBase, IClassFixture<AddBookAndCategoryFixture>
    {
        private Random RandomBook { get; } = new Random();

        private readonly BookHelper _bookHelper;

        private readonly AddBookAndCategoryFixture _addBookAndCategoryFixture;

        public PutBookTests(AddBookAndCategoryFixture addBookAndCategoryFixture)
        {
            _addBookAndCategoryFixture = addBookAndCategoryFixture;
            _bookHelper = new BookHelper();
        }
    

    [Fact]
        public void Scenario_1_As_a_user_I_can_update_a_book()
        {
            // Create a new book category and book to update using the fixtures

            // Create new book category & capture its ID
            var bookCategoryData = _addBookAndCategoryFixture.BookData.BookCategoryData;
            var bookCategoryId = bookCategoryData.First().Id;
            var bookData = _addBookAndCategoryFixture.BookData.BookData;
            var bookId = bookData.First().Id;

            // Set up the request body for a new book using our base customisation
            var addBookRequest = SetupWithoutSave<AddBookRequest>();

            // Base customisation sets book category to 1 so we should override this
            addBookRequest.BookCategoryId = bookCategoryId;




            // Setting up the request body for updating a book
            var updateBookRequest = SetupWithoutSave<UpdateBookRequest>();

            updateBookRequest.Id = 1500;
            updateBookRequest.Title = "All My Friends Are Alive";
            updateBookRequest.Description = "If you're a dinosaur, all of your friends are dead. If you're a pirate, all of your friends have scurvy. If you're a tree, all of your friends are end tables.";
            updateBookRequest.Author = "Avery Monsen, Jory John, Rose Hadley";
            updateBookRequest.PublishedYear = 2022;
            updateBookRequest.AvailableFrom = DateTimeOffset.Now;
            updateBookRequest.BookCategoryId = 13;
            updateBookRequest.HasEBook = true;

            // Call the get API to update given book with above details
            var updateBookResponse = Put<UpdateBookRequest>(updateBookRequest, Resources.UpdateBook);

            // Check the status code is ok
            updateBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        }
    }
}
