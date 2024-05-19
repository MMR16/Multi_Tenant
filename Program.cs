
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.Configure<TenantSettings>(builder.Configuration
// .GetSection(nameof(TenantSettings)));

TenantSettings options=new();
builder.Configuration.GetSection(nameof(TenantSettings))
.Bind(options);

builder.Services.AddScoped<ITenantService,TenantService>();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
