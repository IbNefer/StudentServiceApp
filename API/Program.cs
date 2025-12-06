using Infrastructure.DI;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(typeof(Application.Mappings.MappingProfile));

// B. Controllers (Una sola vez)
builder.Services.AddControllers();

// C. Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();


builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// 2. MIDDLEWARE
// --------------------------------------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("WebUi");
app.UseHttpsRedirection();

app.UseAuthentication(); // Importante para Identity
app.UseAuthorization();

app.MapControllers();

app.Run();