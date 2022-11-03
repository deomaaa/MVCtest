var builder = WebApplication.CreateBuilder(args);

// добавляем поддержку контроллеров с представлениями
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ITimeService, SimpleTimeService>();
var app = builder.Build();

// устанавливаем сопоставление маршрутов с контроллерами
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

