using MicroServiceCRUD.Models;

namespace MicroServiceCRUD.Repositories.Interfaces
{
    public interface IADSORepository
    {
        Task<List<ADSO>> GetADSO();

        Task<bool> PostADSO(ADSO adso);
    }
}
