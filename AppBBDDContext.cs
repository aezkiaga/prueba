using Microsoft.EntityFrameworkCore;

namespace Prueba
{
    public class AppBBDDContext :  DbContext
    {
        public DbSet<Chiste> Chistes { get; set; }
        public DbSet<Tematica> Tematicas { get; set; }
        public DbSet<TematicasChistes> TematicasChistes { get; set; }
        public AppBBDDContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chiste>();
            modelBuilder.Entity<Tematica>();
            modelBuilder.Entity<TematicasChistes>().HasKey(o => new { o.IDChiste, o.IDTematica });
            //modelBuilder.Entity<UserApplications>().HasOne(ua => ua.User).WithMany(u => u.Applications).HasForeignKey(u => u.AppId);
            //modelBuilder.Entity<UserApplications>().HasOne(ua => ua.Application).WithMany(u => u.Users).HasForeignKey(u => u.UUid);

        }
    }
}
