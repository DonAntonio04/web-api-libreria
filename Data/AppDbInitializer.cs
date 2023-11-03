﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using libreriaa_JAMB.Data.Models;
using System.Linq;
using System;

namespace libreriaa_JAMB.Data
{
    public class AppDbInitializer
    {
        public static  void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                {
                   if(!context.Books.Any())
                    {
                        context.Books.AddRange(new Book()
                        {
                            Titulo = "1st Book Title",
                            Descripcion = "1st Book Descripcion",
                            IsRead = true,
                            DateRead = DateTime.Now.AddDays(-10),
                            Rate = 4,
                            Genero = "Biography",
                            Autor = "1st Author",
                            CoverUrl = "https...",
                            DateAdded = DateTime.Now,
                        },
                        new Book()
                        {
                            Titulo = "2nd Book Title",
                            Descripcion = "2nd Book Descripcion",
                            IsRead = true,
                            Genero = "Biography",
                            Autor = "2nd Author",
                            CoverUrl = "https...",
                            DateAdded = DateTime.Now,
                        });
                        context.SaveChanges();
                    }
                } 
            }
        }
    }
}
