using Business.Application;
using Business.AutoMapper;
using Business.Interface;
using Data.Interface;
using Data.Repository;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton(connectionString);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(PersonalProfile).Assembly);
builder.Services.AddAutoMapper(typeof(HijoProfile).Assembly);
builder.Services.AddHttpContextAccessor();


builder.Services.AddScoped<IPersonalRepository, PersonalRepository>();
builder.Services.AddScoped<IPersonalApplication, PersonalApplication>();
builder.Services.AddScoped<IHijoRepository, HijoRepository>();
builder.Services.AddScoped<IHijoApplication, HijoApplication>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");


app.Run();
