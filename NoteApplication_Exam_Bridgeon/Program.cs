using NoteApplication_Exam_Bridgeon.Data.AppliactionDbContext;
using NoteApplication_Exam_Bridgeon.Entities.Models.NoteModels;
using NoteApplication_Exam_Bridgeon.Entities.Models.UserModels;
using NoteApplication_Exam_Bridgeon.Mappings;


var builder = WebApplication.CreateBuilder(args);


//DbContext as a service
builder.Services.AddScoped<NoteDbContext>();


// Add services to the container.
builder.Services.AddAutoMapper(typeof(NoteMapper));


//Service for Dependecy injection
builder.Services.AddScoped<INoteRepository, NoteRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("ReactPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
