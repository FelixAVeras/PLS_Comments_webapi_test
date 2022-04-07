using PLS_Comments_webapi_test.Hub;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(option =>
{
    option.AddPolicy("myPolicy", builder => builder
                                 .WithOrigins("http://localhost:4200")
                                 .AllowAnyMethod()
                                 .AllowCredentials()
                                 .AllowAnyHeader());
                        
});

var app = builder.Build();
app.UseDefaultFiles();

app.MapHub<CommentsHub>("/hub");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("myPolicy");

app.MapControllers();

app.Run();
