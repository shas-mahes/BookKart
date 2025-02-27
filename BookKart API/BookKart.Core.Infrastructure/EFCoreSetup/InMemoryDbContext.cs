﻿using BookKart.Core.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace BookKart.Core.Infrastructure.EFCoreSetup
{
    public class InMemoryDbContext : AppDbContext
    {
        private readonly bool _uniqueDbName;
        public InMemoryDbContext(bool uniqueDbName = false) : base(new DbContextOptionsBuilder<AppDbContext>().Options)
        {
            _uniqueDbName = uniqueDbName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbName = "BookKart_" + (_uniqueDbName ? Guid.NewGuid().ToString() : string.Empty);

            optionsBuilder.UseInMemoryDatabase(dbName);
        }
    }
}
