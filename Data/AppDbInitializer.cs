using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using libreriaa_JAMB.Data.Models;
using System.Linq;
using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
                    
                            CoverUrl = "https...",
                            DateAdded = DateTime.Now,
                        },
                        new Book()
                        {
                            Titulo = "2nd Book Title",
                            Descripcion = "2nd Book Descripcion",
                            IsRead = true,
                            Genero = "Biography",
                            
                            CoverUrl = "https...",
                            DateAdded = DateTime.Now,
                        });
                         context.SaveChanges();

                        try
                        {
                            // Código para insertar en la base de datos
                        }
                        catch (DbUpdateException ex)
                        {
                            // Acceder a la excepción interna para obtener más detalles
                            if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
                            {
                                // Aquí puedes manejar el error de clave foránea
                                // Puedes obtener detalles adicionales de la excepción sqlEx
                                Console.WriteLine("Error de clave foránea: " + sqlEx.Message);
                            }
                            else
                            {
                                // Otro tipo de error durante la actualización de la base de datos
                                Console.WriteLine("Error al actualizar la base de datos: " + ex.Message);
                            }
                        }

                    }
                } 
            }
        }
    }
}
