using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApplication1.Models; // Предположим, что здесь находится ваша модель Result
using Microsoft.EntityFrameworkCore; // Подключаем Entity Framework

namespace WebApplication1.Controller
{
    public class FileUploadController : ControllerBase
    {
        private readonly DBContext _context; // Подставьте ваш контекст базы данных

        public FileUploadController(DBContext context) // Инициализация через конструктор
        {
            _context = context;
        }
        //счетчик строк
        [HttpPost("upload")]
        public async Task<IActionResult> UploadCsvFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty");
            }
            int sum = 1;
            try
            {
                List<(DateTime, int, double)> data = new List<(DateTime, int, double)>();

                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                    {
                        
                        var line = await reader.ReadLineAsync();
                        var values = line.Split(';');

                        if (DateTime.TryParseExact(values[0], "yyyy-MM-dd_HH-mm-ss", null, System.Globalization.DateTimeStyles.None, out DateTime dateTime) &&
                            int.TryParse(values[1], out int seconds) && double.TryParse(values[2].Replace(',', '.'), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out double indicatorValue)
                            && (DateTime.Parse(values[0]) <= DateTime.Now.Date && DateTime.Parse(values[0]) >= new DateTime(2000, 1, 1)) && double.Parse(values[2])>=0 && (sum>0 && sum<10000))
                        {
                            sum++;
                            var newValue = new ValueModel
                            {
                                Id = 1,
                                FileName = file.Name,
                                DateTime = dateTime.ToUniversalTime(),
                                TimeInSeconds = 0,
                                IndicatorValue = indicatorValue
                                
                            };

                            await _context.Value.AddAsync(newValue);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                
                // Обработка данных, например, сохранение в базу данных

                return Ok("File uploaded successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }


        }
    }
}