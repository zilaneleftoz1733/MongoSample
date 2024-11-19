using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace WebApiMin.Models.Entities
{
    [Collection("Persons")]
    public class Person
    {
        public ObjectId  _id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public bool Gender { get; set; }
    }
}
