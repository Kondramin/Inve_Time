using Inve_Time.DataBase.dll.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Inve_Time.DataBase.dll.Context
{
    public class InveTimeDB : DbContext
    {


        #region Entities


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<ProductBase> ProductsBase { get; set; }
        public DbSet<ProductInvented> ProductsInvented { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategorySearchWord> CategorySearchWords { get; set; }
        public DbSet<InventarisationEvent> InventarisationEvents { get; set; }
        public DbSet<Password> Passwords { get; set; }


        #endregion


        public InveTimeDB([NotNullAttribute] DbContextOptions options) : base(options) { }


        #region Initial Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category[]
                {
                new Category { Id=1, Name="Внешние аккумуляторы" },
                new Category { Id=2, Name="Ноутбуки" },
                new Category { Id=3, Name="Рюкзаки/сумки/чемоданы" },
                new Category { Id=4, Name="Мобильные телефоны" },
                new Category { Id=5, Name="Чехлы/бампера/книги для телефона" },
                new Category { Id=6, Name="Защитные стёкла/плёнки" },
                new Category { Id=7, Name="Умные часы/браслеты" },
                new Category { Id=8, Name="Ремешки для часов/браслетов" },
                new Category { Id=9, Name="Видеорегистраторы" },
                new Category { Id=10, Name="Карты памяти" },
                new Category { Id=11, Name="Батарейки" },
                new Category { Id=12, Name="IP-камеры" },
                new Category { Id=13, Name="Мыши компьютерные" },
                new Category { Id=14, Name="Портативная аккустика" },
                new Category { Id=15, Name="Гарнитуры" },
                new Category { Id=16, Name="Сетевое оборудование" },
                new Category { Id=17, Name="Телевизоры" },
                new Category { Id=18, Name="Медиаплееры" },
                new Category { Id=19, Name="Умный дом" },
                new Category { Id=20, Name="Техника для уборки" },
                new Category { Id=21, Name="Транспорт" },
                new Category { Id=22, Name="Освещение" },
                new Category { Id=23, Name="Кабели" },
                new Category { Id=24, Name="Прочее" }
                });
            modelBuilder.Entity<CategorySearchWord>().HasData(
                new CategorySearchWord[]
                {
                    new CategorySearchWord{ Id=1, Name="внешний", CategoryId=1 },
                    new CategorySearchWord{ Id=2, Name="ноутбук", CategoryId=2 },
                    new CategorySearchWord{ Id=3, Name="рюкзак", CategoryId=3 },
                    new CategorySearchWord{ Id=4, Name="сумка", CategoryId=3 },
                    new CategorySearchWord{ Id=5, Name="чемодан", CategoryId=3 },
                    new CategorySearchWord{ Id=6, Name="телефон", CategoryId=4 },
                    new CategorySearchWord{ Id=7, Name="чехол", CategoryId=5 },
                    new CategorySearchWord{ Id=8, Name="бампер", CategoryId=5 },
                    new CategorySearchWord{ Id=9, Name="книга", CategoryId=5 },
                    new CategorySearchWord{ Id=10, Name="стекло", CategoryId=6 },
                    new CategorySearchWord{ Id=11, Name="пленка", CategoryId=6 },
                    new CategorySearchWord{ Id=12, Name="браслет", CategoryId=7 },
                    new CategorySearchWord{ Id=13, Name="часы", CategoryId=7 },
                    new CategorySearchWord{ Id=14, Name="ремешок", CategoryId=8 },
                    new CategorySearchWord{ Id=15, Name="видеорегистратор", CategoryId=9 },
                    new CategorySearchWord{ Id=16, Name="памяти", CategoryId=10 },
                    new CategorySearchWord{ Id=17, Name="батар", CategoryId=11 },
                    new CategorySearchWord{ Id=18, Name="IP", CategoryId=12 },
                    new CategorySearchWord{ Id=19, Name="мышь", CategoryId=13 },
                    new CategorySearchWord{ Id=20, Name="колонка", CategoryId=14 },
                    new CategorySearchWord{ Id=21, Name="гарнитура", CategoryId=15 },
                    new CategorySearchWord{ Id=22, Name="Wi-Fi", CategoryId=16 },
                    new CategorySearchWord{ Id=23, Name="телевизор", CategoryId=17 },
                    new CategorySearchWord{ Id=24, Name="TV", CategoryId=18 },
                    new CategorySearchWord{ Id=25, Name="блок", CategoryId=19 },
                    new CategorySearchWord{ Id=26, Name="кнопка", CategoryId=19 },
                    new CategorySearchWord{ Id=27, Name="датчик", CategoryId=19 },
                    new CategorySearchWord{ Id=28, Name="пылесос", CategoryId=20 },
                    new CategorySearchWord{ Id=29, Name="швабра", CategoryId=20 },
                    new CategorySearchWord{ Id=30, Name="самокат", CategoryId=21 },
                    new CategorySearchWord{ Id=31, Name="велосипед", CategoryId=21 },
                    new CategorySearchWord{ Id=32, Name="гироскутер", CategoryId=21 },
                    new CategorySearchWord{ Id=33, Name="лампа", CategoryId=22 },
                    new CategorySearchWord{ Id=34, Name="кабель", CategoryId=23 },
                });

            modelBuilder.Entity<Position>().HasData(
                new Position[]
                {
                    new Position{Id=1, Name="Администратор", AccessLevel = 10 },
                    new Position{Id=2, Name="Менеджер магазина", AccessLevel = 5 },
                    new Position{Id=3, Name="Продавец", AccessLevel = 1 }
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Admin", SecondName = "Admin", Login = "Admin", PasswodrId = 1, PositionId = 1 }
                );

            modelBuilder.Entity<Password>().HasData(
                new Password { Id = 1, Name = "admin", EmployeeId = 1 }
                );
        }
        #endregion



    }
}
