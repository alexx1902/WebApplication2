using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("value")]
    public class ValueModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("fileName")]
        public string FileName { get; set; }

        [Column("dateTime")]
       
        public DateTime DateTime { get; set; }

        [Column("timeInSeconds")]
        public int TimeInSeconds { get; set; }

        [Column("indicatorValue")]
        public double IndicatorValue { get; set; }
        
    }

}
