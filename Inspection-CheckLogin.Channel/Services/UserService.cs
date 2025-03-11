using InspectionCheckLogin.Messages;
using MongoDB.Bson;
using MongoDB.Driver;

namespace InspectionCheckLogin.Channel
{
    public class UserService : MongoConnect
    {

        public UserService(string ConnectionString) : base(ConnectionString)
        {
        }

        public async Task<string> CheckIfLogin(LoginRequest request)
        {
            Console.WriteLine(request.Email + request.Password);
            var database = dbClient.GetDatabase("InspectionAppDatabase");
            var collection = database.GetCollection<BsonDocument>("Users");

            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("email", request.Email),
                Builders<BsonDocument>.Filter.Eq("password", request.Password)
            );


            try
            {
                var userExists = await collection.Find(filter).AnyAsync();

                Console.WriteLine($"User Exists: {userExists}");

                return userExists ? "User Exists" : "User Not Found";
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Checking For User: {e.Message}");
                return $"Error: {e.Message}";
            }
        }




    }
}