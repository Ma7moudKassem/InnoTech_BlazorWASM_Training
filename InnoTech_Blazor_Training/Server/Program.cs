using InnoTech_Blazor_Training.Server.Hubs;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => 
                                           options.UseSqlServer(connectionString)
                                                  .EnableDetailedErrors()
                                                  .EnableSensitiveDataLogging()
                                                  .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddScoped<IEmpolyeeRepository, EmpolyeeRepository>();
builder.Services.AddScoped<IEmpolyeeUnitOfWork, EmpolyeeUnitOfWork>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentUnitOfWork, StudentUnitOfWork>();

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(options => { 
                                        options.MimeTypes = ResponseCompressionDefaults.MimeTypes
                                        .Concat(new[] { "application/octet-stream" }); });

builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.UseWebAssemblyDebugging();

else
    app.UseHsts();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.MapHub<ChatHub>("/chathub");
app.MapFallbackToFile("index.html");

app.Run();
