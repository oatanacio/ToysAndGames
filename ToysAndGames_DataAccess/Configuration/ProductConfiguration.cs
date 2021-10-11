using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysAndGames_Models.Models;

namespace ToysAndGames_DataAccess.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasData(
                new Product
                {
                    Product_Id = 1,
                    Name = "Scrabble",
                    Description = "Word Game",
                    AgeRestriction = 99,
                    Company = "Mattel",
                    Price = 99.99m
                }, new Product
                {
                    Product_Id = 2,
                    Name = "Uno",
                    Description = "Cards Game",
                    AgeRestriction = 99,
                    Company = "Mattel",
                    Price = 49.99m
                });
        }


    }
}
