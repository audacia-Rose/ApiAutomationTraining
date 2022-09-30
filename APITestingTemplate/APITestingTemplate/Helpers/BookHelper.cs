using System;
using System.Collections.Generic;
using System.Net;
using APITestingTemplate.Models.CombinedDTOs;
using APITestingTemplate.Models.Dtos;
using Audacia.Random.Extensions;
using Audacia.Testing.Api;
using FluentAssertions;

namespace APITestingTemplate.Helpers
{
    public class BookHelper : ApiTestsBase, IDisposable
    {
        /* Allows us to generate new book with random words */
        private Random RandomBook { get; } = new();

        /* Allows us to use methods from BookCategoryHelper class */
        private readonly BookCategoryHelper _bookCategoryHelper;

        public BookHelper()
        {
            _bookCategoryHelper = new BookCategoryHelper();
        }

        public AddBookAndCategory PostBook(int bookCategoryId, string bookCategoryName)
        {
            /* Set up the request to add the book */
            var addBookRequest = SetupWithoutSave<AddBookRequest>();

            addBookRequest.BookCategoryId = bookCategoryId;
            //addBookRequest.Title = RandomBook.Word();
            //addBookRequest.Description = RandomBook.Sentence();
            //addBookRequest.Author = $"{RandomBook.Forename()} {RandomBook.Surname()}";
            //addBookRequest.PublishedYear = 2000;
            //addBookRequest.AvailableFrom = RandomBook.Birthday();
            //addBookRequest.HasEBook = true;

            // Send the request to add the book
            var addBookResponse =
                Post<GetBookDtoCommandResult>(addBookRequest, Resources.AddBook, null);
            // Check the correct response is returned
            addBookResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            // Return the book values as the GetBookDto
            return new AddBookAndCategory()
            {
                BookData = new List<GetBookDto>()
                {
                    addBookResponse.Data.Output
                },
                BookCategoryData = new List<GetBookCategoryDto>()
                {
                    new GetBookCategoryDto()
                    {
                        Name = bookCategoryName,
                        Id = bookCategoryId
                    }
                }
            };
        }

        public AddBookAndCategory PostBookAndCategory()
        {
            var bookCategory = _bookCategoryHelper.AddBookCategory();
            return PostBook(bookCategory.Id, bookCategory.Name);
        }

        public void DeleteBook(int bookId)
        {
            // Call the API to delete a book
            var deleteBookResponse = Delete(bookId, Resources.DeleteBook, null);

            // Check the correct response is returned
            deleteBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public void DeleteBookAndCategory(int bookId, int bookCategoryId)
        {
            DeleteBook(bookId);

            _bookCategoryHelper.DeleteBookCategory(bookCategoryId);

        }
    }
}
