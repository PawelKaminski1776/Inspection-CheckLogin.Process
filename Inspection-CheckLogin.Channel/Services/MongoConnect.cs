using MongoDB.Driver;

namespace InspectionCheckLogin.Channel
{
    public class MongoConnect
    {
        protected readonly MongoClient dbClient;
        public MongoConnect(string ConnectionString)
        {
            dbClient = new MongoClient(ConnectionString);

        }

    }
}