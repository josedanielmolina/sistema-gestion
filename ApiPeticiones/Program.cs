using Configuraciones;

var builder = WebApplication.CreateBuilder(args);

ConfigApi.ConfigureServices(builder);

var app = builder.Build();

ConfigApi.ConfigureApp(app);

