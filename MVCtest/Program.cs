var builder = WebApplication.CreateBuilder(args);

// ��������� ��������� ������������ � ���������������
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ITimeService, SimpleTimeService>();
var app = builder.Build();

// ������������� ������������� ��������� � �������������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Start}/{id?}");

app.Run();


interface ITimeService
{
    public string Time();
}
public class SimpleTimeService : ITimeService 
{
    public string Time()
    {
        return DateTime.Now.ToShortTimeString();
    }
}

