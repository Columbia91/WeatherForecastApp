namespace WeatherForecastWPF
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WeatherForecast.Models;

    public class WeatherContext : DbContext
    {
        // Контекст настроен для использования строки подключения "WeatherContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "WeatherForecastWPF.WeatherContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "WeatherContext" 
        // в файле конфигурации приложения.
        public WeatherContext()
            : base("name=WeatherContext")
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Place> Places { get; set; }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}