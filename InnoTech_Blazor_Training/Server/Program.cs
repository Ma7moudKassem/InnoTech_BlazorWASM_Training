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
app.MapFallbackToFile("index.html");

app.Run();
