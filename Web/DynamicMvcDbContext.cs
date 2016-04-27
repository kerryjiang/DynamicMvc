using Microsoft.EntityFrameworkCore;

namespace DynamicMvc.Web
{
    public class DynamicMvcDbContext : DbContext
    {
        public DynamicMvcDbContext(DbContextOptions options)
            : base(options)
        {
            
        }
    }    
}