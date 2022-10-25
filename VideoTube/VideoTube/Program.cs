using DataAccess.DataContext;
using DependencyInjection;

var MiCors = "MiCors";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Config cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MiCors, builder =>
    {
        builder.WithOrigins("*");
        builder.WithHeaders("*");
        builder.WithMethods("*");
    });
});



//set required dependences
IoCRegister.AddDbContext(builder.Services, builder.Configuration.GetConnectionString("VideoConexion"));
IoCRegister.AddServices(builder.Services);
IoCRegister.AddRepository(builder.Services);
    
var app = builder.Build();
var scope = app.Services.CreateScope();

//Sow See DB VideoTube
IoCRegister.SowSeedDbVideoTube(scope);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MiCors);

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

