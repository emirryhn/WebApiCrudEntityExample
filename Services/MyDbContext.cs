using Microsoft.EntityFrameworkCore;

namespace AbsensiApp_Api.Services
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> context) : base(context)
        {

        }

        public DbSet<UserInfo> userInfo { get; set; }
        public DbSet<UserAttendance> userAttendance { get; set; }

    }
}