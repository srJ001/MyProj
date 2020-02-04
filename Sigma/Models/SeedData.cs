//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Sigma.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Sigma.Models
//{
//    public class SeedData
//    {
//        public static void Initialize(IServiceProvider serviceProvider)
//        {
//            using (var context = new CarContext(
//                serviceProvider.GetRequiredService<
//                    DbContextOptions<CarContext>>()))
//            {
//                // Look for any movies.
//                if (context.Car.Any())
//                {
//                    return;   // DB has been seeded
//                }

//                context.Car.AddRange(
//                    new Car
//                    {
//                        Model = "Honda Accord",
//                        EngineCapacity = 3.2f,
//                        TypeOfTransmition = "Mechanical",
//                        AdditionalCharacteristics = "qedqwdq",
//                        PriceRatio = 1.2f
//                    },

//                    new Car
//                    {
//                        Model = "Honda Accord",
//                        EngineCapacity = 3.2f,
//                        TypeOfTransmition = "Mechanical",
//                        AdditionalCharacteristics = "qedqwdq",
//                        PriceRatio = 1.2f
//                    },

//                    new Car
//                    {
//                        Model = "Honda Accord",
//                        EngineCapacity = 3.2f,
//                        TypeOfTransmition = "Mechanical",
//                        AdditionalCharacteristics = "qedqwdq",
//                        PriceRatio = 1.2f
//                    },

//                    new Car
//                    {
//                        Model = "Honda Accord",
//                        EngineCapacity = 3.2f,
//                        TypeOfTransmition = "Mechanical",
//                        AdditionalCharacteristics = "qedqwdq",
//                        PriceRatio = 1.2f
//                    }
//                ) ;
//                context.SaveChanges();
//            }
//        }
//    }
//}
