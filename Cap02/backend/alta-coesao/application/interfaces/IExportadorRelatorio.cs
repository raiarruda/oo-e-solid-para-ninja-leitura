public interface IExportadorRelatorio
{
    byte[] Exportar(List<decimal> dados);
}