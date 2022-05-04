using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;
using Template.Domain.Models;

namespace Template.Data.Extensions
{
    
    
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ApplyGlobalConfigurations(this ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(Entity.Id):
                            property.IsKey();
                            break;
                        case nameof(Entity.DateUpdated):
                            property.IsNullable = true;
                            break;
                        case nameof(Entity.DateCreated):
                            property.IsNullable = false;
                            property.SetDefaultValue(DateTime.Now);
                            break;
                        case nameof(Entity.IsDeleted):
                            property.IsNullable = false;
                            property.SetDefaultValue(false);
                            break;
                        default:
                            break;
                    }
                }
            }
            return builder;
        }
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(
                new User { Id = Guid.Parse("ed391cc44a1448709a81812d22243dd1"), Name = "User Default", Email = "userdefault@template.com", DateCreated = new DateTime (2022,5,1), IsDeleted = false, DateUpdated = null}
                ); 
            
            return builder;
        }
    }
}
