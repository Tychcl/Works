using Microsoft.EntityFrameworkCore;
using pr45.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddMvc(o => o.EnableEndpointRouting = false);
builder.Services.AddDbContext<Context>(o => o.UseMySql("server=localhost;uid=root;pwd=;database=pr45", new MySqlServerVersion(new Version(8, 0, 30))));
//builder.Services.AddDbContext<KP.Context>(o => o.UseMySql("server=localhost;uid=root;pwd=;database=LibraryFund", new MySqlServerVersion(new Version(8, 0, 30))));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "����������� ��� ������������� ��������",
        Description = "������ ����������� ��� ������������� �������� ����������� � �������"
    });
    c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v2",
        Title = "����������� ��� ������������� ��������",
        Description = "������ ����������� ��� ������������� �������� ����������� � �������"
    });
    c.SwaggerDoc("v3", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v3",
        Title = "����������� ��� ������������� ��������",
        Description = "������ ����������� ��� ������������� �������� ����������� � �������"
    });
    c.SwaggerDoc("v4", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v4",
        Title = "����������� ��� ������������� ��������",
        Description = "������ ����������� ��� ������������� �������� ����������� � �������"
    });
    var fp = Path.Combine(AppContext.BaseDirectory, "pr45.xml");
    c.IncludeXmlComments(fp);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseMvcWithDefaultRoute();
app.UseSwagger();
app.UseSwaggerUI(c =>
{ c.SwaggerEndpoint("/swagger/v1/swagger.json", "������� GET");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "������� POST");
    c.SwaggerEndpoint("/swagger/v3/swagger.json", "������� PUT");
    c.SwaggerEndpoint("/swagger/v4/swagger.json", "������� DELETE");
});
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
