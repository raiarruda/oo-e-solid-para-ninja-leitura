# 📖 Capítulo 02 — A coesão e o tal do SRP

---

## 💡 Resumo

1 - O que é Coesão?
O quanto uma classe tem um propósito **claro e unico** 
Uma classe coesa:
- faz uma coisa bem definida
- tem um conjunto de metodos e atributos que conversam entre si


## Exemplo de BAIXA coesão

Essa classe muda se:

- mudar regra de pagamento
- mudar banco
- mudar antifraude
- mudar email

```csharp
public class CartaoService
{
    public void ProcessarPagamento(Cartao cartao, decimal valor)
    {
        // regra de negócio
        if (valor > cartao.Limite)
            throw new Exception("Limite excedido");

        cartao.Limite -= valor;

        // persistência
        _db.Save(cartao);

        // antifraude
        _antifraude.Validar(cartao, valor);

        // notificação
        _email.Enviar(cartao.Cliente);
    }
}
```

``` ts
export function useCartao() {
  const processarPagamento = () => {}
  const salvar = () => {}
  const validarFraude = () => {}
  const enviarEmail = () => {}

  return { processarPagamento, salvar, validarFraude, enviarEmail }
}
```

## Exemplo de ALTA coesão 

```csharp
public class ProcessadorPagamento
{
    public void Processar(Cartao cartao, decimal valor)
    {
        if (valor > cartao.Limite)
            throw new Exception("Limite excedido");

        cartao.Debitar(valor);
    }
}

public class CartaoRepository
{
    public void Salvar(Cartao cartao) { }
}

public class AntifraudeService
{
    public void Validar(Cartao cartao, decimal valor) { }
}

public class NotificacaoService
{
    public void Enviar(Cliente cliente) { }
}
``` 

```ts
export function usePagamento() {
  const processar = () => {}

  return { processar }
}

export function useAntifraude() {
  const validar = () => {}

  return { validar }
}
```

