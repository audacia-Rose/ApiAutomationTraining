using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using APITestingTemplate.Models.Dtos;
using Audacia.Random.Extensions;
using Audacia.Testing.Api;
using FluentAssertions;

namespace APITestingTemplate.Helpers
{
    public class BookCategoryHelper : ApiTestsBase, IDisposable
    {
        /* Create new instance of Random Class */
        //private Random Random { get; } = new Random();
        private Random RandomBook { get; } = new();

        /* Create method for setting up and adding new book category */
        public GetBookCategoryDto AddBookCategory()
        {
            /* Set up request for adding book category */
            var addBookCategoryRequest = SetupWithoutSave<AddBookCategoryRequest>();

            /* Use new instance of Random Class to generate 3-worded book genre name */
            addBookCategoryRequest.Name = RandomBook.Word();
            
            /* Send request to add book category with given name */
            var addBookCategoryResponse =
                Post<GetBookCategoryDtoCommandResult>(addBookCategoryRequest, Resources.AddBookCategory, null);

            /* Check that the request was successful and the new book category was added */
            addBookCategoryResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            /* Return the newly created book category's name & its ID */
            return new GetBookCategoryDto()
            {
                Name = addBookCategoryResponse.Data.Output.Name,
                Id = addBookCategoryResponse.Data.Output.Id
            };
        }

        /* Create method for deleting book category by ID */
        public void DeleteBookCategory(int bookCategoryId)
        {
            /* Send the request to delete the book category */
            var deleteBookCategoryResponse =
                Delete<GetBookCategoryDtoCommandResult>(bookCategoryId, Resources.BookCategory, null);

            /* Check that the book category has been deleted & correct response is returned */
            deleteBookCategoryResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
