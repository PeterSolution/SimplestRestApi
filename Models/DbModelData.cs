
using System.ComponentModel.DataAnnotations;
namespace TestProject.Models
{
    public class DbModelData
    {
        [Key]
        public int id { get; set; }
        public string data { get; set; }    
    }
}
