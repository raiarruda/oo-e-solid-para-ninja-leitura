public class ExportadorCsv : IExportadorRelatorio
{
    public byte[] Exportar(List<decimal> dados)
    {
        var csv = string.Join(",", dados);
        return Encoding.UTF8.GetBytes(csv);
    }
}