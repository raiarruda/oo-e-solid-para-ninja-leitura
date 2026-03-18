public class ProcessadorDeDados
{
    public List<decimal> Processar(List<Dado> dados)
    {
        return dados.Select(d => d.Valor * 2).ToList();
    }
}