﻿


using CourserProvider.Infrastructure.Data.Entities;
using CourserProvider.Infrastructure.Models;
using SiliconWebAPI.Infrastructure.Data.Entities;


namespace CourserProvider.Infrastructure.Factories;

public static class CourseFactory
{

    public static CourseEntity Create(CourseCreateRequest request) 
    {
        return new CourseEntity
        {
            ImageUri = request.ImageUri,
            ImageHeaderUri = request.ImageHeaderUri,
            IsBestSeller = request.IsBestSeller,
            isDigital = request.isDigital,
            Categories = request.Categories,
            Title = request.Title,
            Ingress = request.Ingress,
            StarRating = request.StarRating,
            Reviews = request.Reviews,
            LikesInPercent = request.LikesInPercent,
            Likes = request.Likes,
            Hours = request.Hours,
            Authors = request.Authors?.Select(a => new AuthorEntity
            {
                Name = a.Name
            }).ToList(),
            Prices = request.Prices == null ? null : new PriceEntity
            {
                Currency = request.Prices.Currency,
                Price = request.Prices.Price,
                Discount = request.Prices.Discount
            },
            Content = request.Content == null ? null : new ContentEntity
            {
                Description = request.Content.Description,
                Includes = request.Content.Includes,
                ProgramDetails = request.Content.ProgramDetails?.Select(pd => new ProgramDetailItemEntity
                {
                    Id = pd.Id,
                    Title = pd.Title,
                    Description = pd.Description
                }).ToList()
            }


        };
    
    }


    public static CourseEntity Create(CourseUpdateRequest request)
    {
        return new CourseEntity
        {
            Id = request.Id,
            ImageUri = request.ImageUri,
            ImageHeaderUri = request.ImageHeaderUri,
            IsBestSeller = request.IsBestSeller,
            isDigital = request.isDigital,
            Categories = request.Categories,
            Title = request.Title,
            Ingress = request.Ingress,
            StarRating = request.StarRating,
            Reviews = request.Reviews,
            LikesInPercent = request.LikesInPercent,
            Likes = request.Likes,
            Hours = request.Hours,
            Authors = request.Authors?.Select(a => new AuthorEntity
            {
                Name = a.Name
            }).ToList(),
            Prices = request.Prices == null ? null : new PriceEntity
            {
                Currency = request.Prices.Currency,
                Price = request.Prices.Price,
                Discount = request.Prices.Discount
            },
            Content = request.Content == null ? null : new ContentEntity
            {
                Description = request.Content.Description,
                Includes = request.Content.Includes,
                ProgramDetails = request.Content.ProgramDetails?.Select(pd => new ProgramDetailItemEntity
                {
                    Id = pd.Id,
                    Title = pd.Title,
                    Description = pd.Description
                }).ToList()
            }


        };

    }

    public static Course Create(CourseEntity entity)
    {
        return new Course
        {
            Id = entity.Id,
            ImageUri = entity.ImageUri,
            ImageHeaderUri = entity.ImageHeaderUri,
            IsBestSeller = entity.IsBestSeller,
            isDigital = entity.isDigital,
            Categories = entity.Categories,
            Title = entity.Title,
            Ingress = entity.Ingress,
            StarRating = entity.StarRating,
            Reviews = entity.Reviews,
            LikesInPercent = entity.LikesInPercent,
            Likes = entity.Likes,
            Hours = entity.Hours,
            Authors = entity.Authors?.Select(a => new Author
            {
                Name = a.Name
            }).ToList(),
            Prices = entity.Prices == null ? null : new Prices
            {
                Currency = entity.Prices.Currency,
                Price = entity.Prices.Price,
                Discount = entity.Prices.Discount
            },
            Content = entity.Content == null ? null : new Content
            {
                Description = entity.Content.Description,
                Includes = entity.Content.Includes,
                ProgramDetails = entity.Content.ProgramDetails?.Select(pd => new ProgramDetailItem
                {
                    Id = pd.Id,
                    Title = pd.Title,
                    Description = pd.Description
                }).ToList()
            }


        };

    }
}
