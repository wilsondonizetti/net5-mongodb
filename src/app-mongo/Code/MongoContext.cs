using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

public class MongoContext
{
    private readonly IMongoDatabase _database = null;

    public MongoContext(IOptions<PropectSettings> settings)
    {
        var client = new MongoClient(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
        if (client != null)
            _database = client.GetDatabase(Environment.GetEnvironmentVariable("DATABASE_MONGO"));
    }

    public IMongoCollection<Prospects> Prospects
    {
        get
        {
            return _database.GetCollection<Prospects>("prospects");
        }
    }
}