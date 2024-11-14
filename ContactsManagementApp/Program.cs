using ContactsManagementApp.BusinessLogics;
using ContactsManagementApp.DataServices;
using ContactsManagementApp.Handler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddTransient<IContactService, ContactService>();
builder.Services.AddSingleton(typeof(DataService), (srv) => { var data = new DataService(); data.LoadData("contact.json").Wait(); return data; });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>
{
    options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
});
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
