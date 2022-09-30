using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APITestingTemplate.Fixtures;
using Audacia.Testing.Api;
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
        public void Scenario_1_As_a_user_I_can_delete_a_book_by_its_Id()
        {


        }
        
        [Trait("Category", "Delete Books")]
        [Fact]
        public void Scenario_1_As_a_user_I_can_delete_a_book_category_by_its_Id()
        {


        }


    }
}
