public class RelatorioService
{
    public byte[] GerarRelatorio(List<Dado> dados, string formato)
    {
        // regra de transformação
        var processados = dados.Select(d => d.Valor * 2).ToList();

        // decisão de formato
        if (formato == "CSV")
        {
            var csv = string.Join(",", processados);
            return Encoding.UTF8.GetBytes(csv);
        }

        if (formato == "PDF")
        {
            var pdf = $"PDF: {string.Join(",", processados)}";
            return Encoding.UTF8.GetBytes(pdf);
        }

        // log
        Console.WriteLine("Relatório gerado");

        return Array.Empty<byte>();
    }
}