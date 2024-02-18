using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("result")]
    public class ResultModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("filename")]
        public string FileName { get; set; } = "";
        [Column("totalTime")]
        public TimeSpan TotalTime { get; set; }

        [Column("startTime")]
        public DateTime StartTime { get; set; }

        [Column("averageExecutionTime")]
        public double AverageExecutionTime { get; set; }

        [Column("averageIndicatorValue")]
        public double AverageIndicatorValue { get; set; }

        [Column("medianIndicatorValue")]
        public double MedianIndicatorValue { get; set; }

        [Column("maxIndicatorValue")]
        public decimal MaxIndicatorValue { get; set; }

        [Column("minIndicatorValue")]
        public decimal MinIndicatorValue { get; set; }

        [Column("rowsCount")]
        public int RowsCount { get; set; }

        [Column("valueId")]
        public int ValueId { get; set; }
        
        public ValueModel Value { get; set; } 
    }

}
