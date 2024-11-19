using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApiMin.Models;
using WebApiMin.Models.DbContexts;
using WebApiMin.Models.Entities;

namespace WebApiMin
{
    public class Program(IServiceCollection services)
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateSlimBuilder(args);

            builder.Services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
            });
            builder.Services.AddSingleton<MongoDBService>();
            builder.Services
                .AddDbContext<MongoDbContext>(
                p => p.UseMongoDB(@"mongodb://root:qweasd@mongo:27017/", "IstkaFullData"));


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();


            #region Default gelen kodlar kapatildi
            //var sampleTodos = new Todo[] {
            //    new(1, "Walk the dog"),
            //    new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
            //    new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
            //    new(4, "Clean the bathroom"),
            //    new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
            //};

            //var todosApi = app.MapGroup("/todos");

            //todosApi.MapGet("/", () => sampleTodos);
            //todosApi.MapGet("/{id}", (int id) =>
            //    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
            //        ? Results.Ok(todo)
            //        : Results.NotFound());
            ////myTodoDelegate mydelegate= new myTodoDelegate(GetGorevler);
            //var mysampleTodos = new Todo[] {
            //    new(1, "Gorev 1"),
            //    new(2, "Gorev 2", DateOnly.FromDateTime(DateTime.Now)),
            //    new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
            //    new(4, "Clean the bathroom"),
            //    new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
            //};
            //todosApi.MapGet("/Gorevler", ()=>mysampleTodos); 
            #endregion

            #region MongoDB.Driver
            //app.MapPost("/create-person", async (PersonVM personVM, MongoDBService mongoDBService) =>
            //{
            //    IMongoCollection<Person> personCollection = mongoDBService.GetCollection<Person>();
            //    await personCollection.InsertOneAsync(new()
            //    {
            //        Name = personVM.Name,
            //        Surname = personVM.Surname,
            //        Age = personVM.Age,
            //    });
            //});
            //app.MapGet("/get-persons", async (MongoDBService mongoDBService) =>
            //{
            //    IMongoCollection<Person> personCollection = mongoDBService.GetCollection<Person>();
            //    return await (await personCollection.FindAsync(p => true)).ToListAsync();
            //});
            #endregion

            #region MongoDB Entity Framework Core Provider
            //app.MapPost("/create-database", async (ApplicationDbContext context) => context.Database.EnsureCreated());
            //app.MapPost("/create-person", async (PersonVM personVM, ApplicationDbContext context) =>
            //{
            //    await context.Persons.AddAsync(personVM);
            //    await context.SaveChangesAsync();
            //});
            //app.MapGet("/get-persons", async (ApplicationDbContext context) => await context.Persons.ToListAsync());
            #endregion



            app.Run();
        }
        public delegate Todo[] myTodoDelegate();
        public static Todo[] GetGorevler()
        {
            var mysampleTodos = new Todo[] {
                new(1, "Gorev 1"),
                new(2, "Gorev 2", DateOnly.FromDateTime(DateTime.Now)),
                new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
                new(4, "Clean the bathroom"),
                new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
            };
            return mysampleTodos;
        }
    }







    public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

    [JsonSerializable(typeof(Todo[]))]
    internal partial class AppJsonSerializerContext : JsonSerializerContext
    {

    }
}