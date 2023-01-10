using Microsoft.EntityFrameworkCore;
using NameGame.Models.Domain;
using NameGame.Models.Network;
using Newtonsoft.Json;

namespace NameGame.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NameGameContext(serviceProvider.GetRequiredService<DbContextOptions<NameGameContext>>()))
            {
                var file = await new HttpClient().GetStringAsync("https://namegame.willowtreeapps.com/api/v1.0/profiles");
                var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeNetwork>>(file);

                if (!context.Employees.Any())
                {
                    var employeesdata = new List<Employee>();

                    foreach (var employee in employees)
                    {
                        employeesdata.Add(new Employee
                        {
                            EmployeeId = employee.Id,
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            Type = employee.Type,
                            JobTitle = employee.JobTitle,
                            Slug = employee.Slug,
                        });

                    };

                    await context.Employees.AddRangeAsync(employeesdata);
                    await context.SaveChangesAsync();
                }

                if (!context.Headshots.Any())
                {
                    await context.Headshots.AddRangeAsync(employees.Select(employee => new Headshot
                    {
                        EmployeeId = employee.Id,
                        HeadshotId = employee.Headshot.Id,
                        Alt = employee.Headshot.Alt,
                        Height = employee.Headshot.Height,
                        Width = employee.Headshot.Width,
                        MimeType = employee.Headshot.MimeType,
                        Type = employee.Headshot.Type,
                        Url = employee.Headshot.Url
                    }));

                    await context.SaveChangesAsync();
                }

                if (!context.SocialLinks.Any())
                {
                    var socialLinks = new List<SocialLink>();
                    foreach (var employee in employees)
                    {
                        socialLinks.AddRange(employee.SocialLinks.Select(socialLink => new SocialLink
                        {
                            CallToAction = socialLink.CallToAction,
                            Url = socialLink.Url,
                            Type = socialLink.Type,
                            EmployeeId = employee.Id
                        }));

                        await context.SocialLinks.AddRangeAsync(socialLinks);
                    }

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
