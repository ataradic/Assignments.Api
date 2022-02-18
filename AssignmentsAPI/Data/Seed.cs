using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AssignmentsAPI.Data;
using AssignmentsAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssignmentsAPI.Data
{
    public class Seed
    {
       
        public static async Task SeedTypesStatus(DataContext context)
        {
            if (await context.AssignmentsTypes.AnyAsync()) return;
            var typeData = await System.IO.File.ReadAllTextAsync("Data/TypesSeedData.json");
            var types = JsonSerializer.Deserialize<List<Type>>(typeData);
            types.ForEach(type => context.AssignmentsTypes.Add(type));
            await context.SaveChangesAsync();
        }
    }
}