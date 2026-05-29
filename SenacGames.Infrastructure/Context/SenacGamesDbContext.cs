using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SenacGames.Domain.Entities;
using SenacGames.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacGames.Infrastructure.Context
{
    public class SenacGamesDbContext : IdentityDbContext
    {
        public SenacGamesDbContext(DbContextOptions<SenacGamesDbContext> options)
            :base(options)
        {
            
        }
        /// <summary>
        /// DbSet que representa a tabela de games no banco de dados. Cada instância de Game corresponde a uma linha na tabela, e as propriedades da classe Game correspondem às colunas da tabela. O Entity Framework Core usa esse DbSet para realizar operações de CRUD (Create, Read, Update, Delete) nos registros de jogos no banco de dados.
        /// </summary>
        public DbSet<Game> Games { get; set; }

        /// <summary>
        /// DbSet que representa a tabela de categorias no banco de dados. Cada instância de Category corresponde a uma linha na tabela, e as propriedades da classe Category correspondem às colunas da tabela. O Entity Framework Core usa esse DbSet para realizar operações de CRUD (Create, Read, Update, Delete) nos registros de categorias no banco de dados.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
