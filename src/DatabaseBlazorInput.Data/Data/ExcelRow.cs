using System.ComponentModel.DataAnnotations;

namespace DatabaseBlazorInput.Data.Data;

public class ExcelRow
{
    [Key]
    public int Id { get; set; }

    public string? ColumnA { get; set; }
    public string? ColumnB { get; set; }
    public string? ColumnC { get; set; }
}
