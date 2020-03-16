namespace Shop.Web.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly UserManager<User> userManager;
        private Random random;

        public SeedDb(DataContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userManager.FindByEmailAsync("mmbtrs@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Fabián",
                    LastName = "Ordóñez",
                    Email = "mmbtrs@gmail.com",
                    UserName = "mmbtrs@gmail.com",
                    PhoneNumber = "3127857713"
                };

                var result = await this.userManager.CreateAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("No se pudo crear el usuario en el inicializador");
                }
            }


            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone X", user);
                this.AddProduct("Magic Mouse", user);
                this.AddProduct("iWatch Series 4", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user
            });

        }
    }
}
