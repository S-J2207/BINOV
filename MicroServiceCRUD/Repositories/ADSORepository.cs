using MicroServiceCRUD.Models;
using MicroServiceCRUD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceCRUD.Repositories
{
    public class ADSORepository : IADSORepository
    {
        private readonly DatabaseService context;

        public ADSORepository(DatabaseService context)
        {
            this.context = context;
        }

        public async Task<List<ADSO>> GetADSO()
        {
            var data = await context.ADSO.ToListAsync();
            return data;
        }

        public async Task<bool> PostADSO(ADSO adso)
        {
            await context.ADSO.AddAsync(adso);
            await context.SaveAsync();
            return true;
        }
    }
}
