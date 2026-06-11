using ClashRoyaleApi.Interfaces;
using ClashRoyaleApi.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<IClashApiInterfaces,ClashApiServices>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddMemoryCache();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",policy =>
    {
        if (builder.Environment.IsDevelopment())
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            ;
        }
        else

        {
            policy
                .WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
            ;
        }
            
    });
});


builder.Services.AddHttpClient<ILlamaInterfaces,LlamaServices>(client =>
{
    client.BaseAddress = new Uri("https://api.groq.com/");
});


builder.Services
    .AddHttpClient<IClashApiInterfaces,ClashApiServices>(client =>
    {
        var baseUrl = builder.Configuration["ClashUrl:BaseUrl"];
        client.BaseAddress = new Uri (baseUrl);
        
        client.DefaultRequestHeaders.Add("Accept","application/json");
        var jwtToken = builder.Configuration["ClashUrl:TokenJwt"];

        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer" , jwtToken);
    });



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.MapControllers();
app.Run();

