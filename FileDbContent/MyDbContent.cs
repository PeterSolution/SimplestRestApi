using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.FileDbContent
{
    public class MyDbContent:DbContext
    {
        public MyDbContent(DbContextOptions opt):base(opt){}
        public DbSet<DbModelData> dbModelDatas { get; set; }
    }
    
}
