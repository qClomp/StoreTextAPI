
using StoreTextAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace StoreTextAPI.Services;

public class STextService
{
    private readonly IMongoCollection<SText> _storetextCollection;

    public STextService( 
        IOptions<DatabaseSettings> DatabaseSettings)
    {
        var mongoClient = new MongoClient( 
            DatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase( 
            DatabaseSettings.Value.DatabaseName);

        _storetextCollection = mongoDatabase.GetCollection<SText>( 
            DatabaseSettings.Value.CollectionName);
    }

    public async Task<List<SText>> GetAsync() =>
        await _storetextCollection.Find(_ => true).ToListAsync();
    public async Task<SText?> GetAsync(string url) =>
        await _storetextCollection.Find(data => data.url == url).FirstOrDefaultAsync();

    public async Task CreateAsync(SText newSText) =>
        await _storetextCollection.InsertOneAsync(newSText);
}