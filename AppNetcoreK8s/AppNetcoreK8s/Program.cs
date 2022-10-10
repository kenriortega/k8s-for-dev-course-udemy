using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .AddEndpointsApiExplorer()
    .AddCors()
    .AddHttpContextAccessor()
    .AddDbContext<ApiContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
    .AddSwaggerGen(options => {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme {
            Description = "Authorization header using the Bearer scheme",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        options.OperationFilter<SecurityRequirementsOperationFilter>();
    });

builder.Services
    .AddProductService(configuration);

builder.Services
    .AddScoped<IProductRepository, ProductRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

//db migrations
using (var scope = app.Services.CreateScope()) {
    var db = scope.ServiceProvider.GetRequiredService<ApiContext>();
    db.Database.Migrate();

    using (var conn = (NpgsqlConnection) db.Database.GetDbConnection()) {
        conn.Open();
    }
}
//

//Services
app
    .MapProductsService();


app.UseCors(policy => policy
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(_ => true) //allow any origin
    .AllowCredentials()
);

app.Run();