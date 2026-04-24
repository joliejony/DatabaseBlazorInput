namespace DatbaseBlazData_.Models
{
    public class ExcelRow
    {
        public int Id { get; set; }

        // Example columns - change these to match your Excel file
        public string LineNumber { get; set; } = string.Empty;
        public string ColumnB { get; set; } = string.Empty;
        public string? ColumnC { get; set; }
    }
}
