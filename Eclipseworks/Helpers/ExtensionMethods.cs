using DataAcess.Context;
using DataAcess.Interfaces;
using DataAcess.Models;
using Microsoft.EntityFrameworkCore;

namespace Eclipseworks.Helpers
{
    public static class ExtensionMethods
    {
        public static void MigrationInitial(this WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                var serviceDB = serviceScope.ServiceProvider.GetService<EclipseDBContext>();
                serviceDB.Database.Migrate();
            }
        }
    }
}
