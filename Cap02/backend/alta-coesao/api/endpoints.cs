var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ProcessadorDeDados>();

builder.Services.AddScoped<ExportadorCsv>();
builder.Services.AddScoped<ExportadorPdf>();

builder.Services.AddScoped<IExportadorRelatorio>(sp =>
{
    // escolha simplificada (poderia vir de query param)
    return sp.GetRequiredService<ExportadorCsv>();
});

builder.Services.AddScoped<GeradorRelatorio>();

var app = builder.Build();

app.MapGet("/relatorio", (
    GeradorRelatorio gerador) =>
{
    var dados = new List<Dado>
    {
        new Dado(10),
        new Dado(20)
    };

    var resultado = gerador.Gerar(dados);

    return Results.File(resultado, "text/plain", "relatorio.csv");
});

app.Run();