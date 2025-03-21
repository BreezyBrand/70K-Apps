using System.ComponentModel.DataAnnotations.Schema;

namespace _70KApps.Models
{
    [Table("SampleModel")]
    public class SampleModel
    {
        public int ID { get; set; }
        public string message { get; set; }
    }
}
