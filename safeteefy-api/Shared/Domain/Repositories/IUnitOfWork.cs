using System.Threading.Tasks;

namespace safeteefy_api.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}