using BookShop.Application.DTOs;
using BookShop.Domain.Entities;
using Mapster;

namespace BookShop.Application.Mappings;

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        //Book => BookSummaryDto
        TypeAdapterConfig.GlobalSettings.NewConfig<Book, BookSummaryDto>()
            .Map(dest => dest.Authors, src => src.BookAuthors.Select(bookAuthor => bookAuthor.Author))
            .Map(dest => dest.Categories, src => src.BookCategories.Select(bookCategory => bookCategory.Category));
        //Book => BookDto
        TypeAdapterConfig.GlobalSettings.NewConfig<Book, BookDto>()
            .Map(dest => dest.Authors, src => src.BookAuthors.Select(bookAuthor => bookAuthor.Author))
            .Map(dest => dest.Categories, src => src.BookCategories.Select(bookCategory => bookCategory.Category))
            .Map(dest => dest.Editions, src => src.BookEditions);
        //BookEdition => BookEditionDto
        TypeAdapterConfig.GlobalSettings.NewConfig<BookEdition, BookEditionDto>()
            //Binding: Id & Name
            .Map(dest => dest.BindingTypeId, src => src.BindingType.Id)
            .Map(dest => dest.BindingType, src => src.BindingType.Name)
            //BookStatus: Id & Name
            .Map(dest => dest.BookStatusId, src => src.BookStatus.Id)
            .Map(dest => dest.Status, src => src.BookStatus.Name)
            //Publisher: Id & Name
            .Map(dest => dest.PublisherId, src => src.Publisher.Id)
            .Map(dest => dest.PublisherName, src => src.Publisher.Name);

        
    }
}