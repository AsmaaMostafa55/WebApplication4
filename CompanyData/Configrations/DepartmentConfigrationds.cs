using CompanyData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Configrations
{
    public class DepartmentConfigrationds : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(x => x.id).UseIdentityColumn(10, 10);
            builder.HasIndex(x => x.name).IsUnique();
        }
    }
}
