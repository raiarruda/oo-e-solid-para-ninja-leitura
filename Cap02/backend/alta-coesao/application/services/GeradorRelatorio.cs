public class GeradorRelatorio
{
    private readonly ProcessadorDeDados _processador;
    private readonly IExportadorRelatorio _exportador;

    public GeradorRelatorio(
        ProcessadorDeDados processador,
        IExportadorRelatorio exportador)
    {
        _processador = processador;
        _exportador = exportador;
    }

    public byte[] Gerar(List<Dado> dados)
    {
        var processados = _processador.Processar(dados);

        return _exportador.Exportar(processados);
    }
}