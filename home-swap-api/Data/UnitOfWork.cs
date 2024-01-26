using System;
using home_swap_api.interfaces;
using home_swap_api.Repository;

namespace home_swap_api.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;
        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IHouseRepository HouseRepository => new HouseRepository(appDbContext);

        public async Task<bool> SaveAsync()
        {
            return await appDbContext.SaveChangesAsync() > 0;
        }
    }
}

