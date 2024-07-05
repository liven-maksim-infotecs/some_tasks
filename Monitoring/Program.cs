WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddData();
builder.Services.AddControllersWithViews()
    .AddJsonOptions(
        options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        });
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
