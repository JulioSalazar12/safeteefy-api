using safeteefy_api.Shared.Persistence.Context;

namespace safeteefy_api.Shared.Persistence.Repositories
{
    public class BaseRepository
    {
        protected AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}