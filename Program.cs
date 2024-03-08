using Livre.configurations;
using Livre.repositories;
using Livre.services;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Exception Handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// Dependency Injection Mappings

// Repositories
builder.Services.AddScoped<LivreDbContext>();
builder.Services.AddScoped<IBooksRepository, BooksRepositoryEFImpl>();
builder.Services.AddScoped<IAuthorsRepository, AuthorsRepositoryEFImpl>();
builder.Services.AddScoped<IGenresRepository, GenresRepositoryEFImpl>();


// Services (We aren't using interfaces here as we will probably never switch out these services for something else.)
builder.Services.AddScoped<BooksService>();
builder.Services.AddScoped<AuthorsService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler(_ => {});

app.UseCors(MyAllowSpecificOrigins);

app.Run();
