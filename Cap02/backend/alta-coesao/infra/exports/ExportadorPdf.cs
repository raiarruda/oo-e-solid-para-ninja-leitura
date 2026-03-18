public class ExportadorPdf : IExportadorRelatorio
{
    public byte[] Exportar(List<decimal> dados)
    {
        var pdf = $"PDF: {string.Join(",", dados)}";
        return Encoding.UTF8.GetBytes(pdf);
    }
}