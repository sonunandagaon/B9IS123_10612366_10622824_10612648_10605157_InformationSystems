using Microsoft.EntityFrameworkCore;
using MusicEquipmentStore.Models;

namespace MusicEquipmentStore.Context
{
    public class ProductData
    {
        public static void ProductDatabase(MusicEquipmentStoreContext context)
        {
            context.Database.Migrate();

            if (!context.Products.Any())
            {
                Category pianos = new Category { Name = "Piano", Slug = "pianos" };
                Category guitars = new Category { Name = "Guitar", Slug = "guitars" };

                context.Products.AddRange(
                        new Product
                        {
                            Name = "Piano1",
                            Slug = "piano1",
                            Description = "Piano 1",
                            Price = 1.50M,
                            Category = pianos,
                            Image = "H_D.jpg"
                        },
                        new Product
                        {
                            Name = "Piano2",
                            Slug = "piano2",
                            Description = "Piano 2",
                            Price = 3M,
                            Category = pianos,
                            Image = "f1_D.jpg"
                        },
                        new Product
                        {
                            Name = "Piano3",
                            Slug = "piano3",
                            Description = "Piano 3",
                            Price = 0.50M,
                            Category = pianos,
                            Image = "f2.2_D.jpg"
                        },
                        new Product
                        {
                            Name = "Guitar1",
                            Slug = "guitar1",
                            Description = "guitar 1",
                            Price = 2M,
                            Category = pianos,
                            Image = "H_D.jpg"
                        },
                        new Product
                        {
                            Name = "Guitar2",
                            Slug = "guitar2",
                            Description = "guitar 2",
                            Price = 5.99M,
                            Category = guitars,
                            Image = "f2.2_D.jpg"
                        },
                        new Product
                        {
                            Name = "Guitar3",
                            Slug = "guitar3",
                            Description = "guitar 3",
                            Price = 7.99M,
                            Category = guitars,
                            Image = "f1_D.jpg"
                        },
                        new Product
                        {
                            Name = "Yellow shirt",
                            Slug = "yellow-shirt",
                            Description = "Yellow shirt",
                            Price = 11.99M,
                            Category = guitars,
                            Image = "yellow shirt.jpg"
                        },
                        new Product
                        {
                            Name = "Grey shirt",
                            Slug = "grey-shirt",
                            Description = "Grey shirt",
                            Price = 12.99M,
                            Category = guitars,
                            Image = "grey shirt.jpg"
                        }
                );

                context.SaveChanges();
            }
        }
    }
}
