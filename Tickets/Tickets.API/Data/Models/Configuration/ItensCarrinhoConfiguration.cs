using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Application.Data.Models;

namespace Tickets.API.Data.Models.Mapping
{
    public class ItensCarrinhoConfiguration : IEntityTypeConfiguration<ItensCarrinho>
    {
        public void Configure(EntityTypeBuilder<ItensCarrinho> builder)
        {
            builder.HasKey(x => new { x.IdCarrinho, x.IdIngresso });
            //builder.HasOne(x => x.Carrinho).WithMany(x => x.Itens).HasForeignKey(x => x.IdCarrinho);
            //builder.HasOne(x => x.Ingresso).WithMany(x => x.ItensCarrinho).HasForeignKey(x => x.IdIngresso);
        }
    }
}
