using System;
using APITestingTemplate.Models.Dtos;
using Audacia.Random.Extensions;
using AutoFixture;
using AutoFixture.Dsl;

namespace APITestingTemplate.DataSetup.Customizations
{
    public class BaseCustomizations : ICustomization
    {
        private Random Random { get; } = new();

        public void Customize(IFixture fixture)
        {
            // Books
            fixture.Register(() =>
                AddBooks(fixture).Create());

        }

        protected virtual IPostprocessComposer<AddBookRequest> AddBooks(IFixture fixture)
        {
            return fixture.Build<AddBookRequest>()
                .With(dto => dto.Title, () => Random.Words(2))
                .With(dto => dto.Description, () => Random.Sentence())
                .With(dto => dto.Author, () => Random.FemaleForename() + ' ' + Random.Surname())
                .With(dto => dto.PublishedYear, () => 2015)
                .With(dto => dto.HasEBook, () => true)
                .With(dto => dto.AvailableFrom, () => DateTime.Parse("2000-01-01T00:00:00.000Z"))
                .With(dto => dto.BookCategoryId, () => 1);
        }
    }

}
