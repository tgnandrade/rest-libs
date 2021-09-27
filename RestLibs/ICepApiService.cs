using Refit;
using System.Threading.Tasks;

namespace RestLibs
{
    public interface ICepApiService
    {
        [Get("/ws/{cep}/json")]
        Task<CepViewModel> GetAddressAsync(string cep);
    }
}
