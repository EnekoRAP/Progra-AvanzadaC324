using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Minombredeconexion : DbContext
    {
        public MinombredeconexionDbContext(DbContextOptions<MinombredeconexionDbContext> options)
            : base(options) { }



        //"ConnectionString": {
        //  "Minombredeconexion": "Server=srv863.hstgr.io;Port=3306;User=u484426513_pac324;Password=B&XWouC#9Ef;Database=u484426513_pac324;"
        //},
    }
}
