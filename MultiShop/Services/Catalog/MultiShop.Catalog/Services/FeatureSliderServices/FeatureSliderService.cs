using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices;

public class FeatureSliderService : IFeatureSliderService
{
    private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
    private readonly IMapper _mapper;

    public FeatureSliderService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _featureSliderCollection = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
    {
        var values = await _featureSliderCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultFeatureSliderDto>>(values);
    }

    public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
    {
        var values = await _featureSliderCollection.Find<FeatureSlider>(x => x.FeatureSliderID == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdFeatureSliderDto>(values);
    }
    public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
    {
        var values = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
        await _featureSliderCollection.InsertOneAsync(values);
    }
    public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
    {
        var values=_mapper.Map<FeatureSlider>(updateFeatureSliderDto);
        await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderID == updateFeatureSliderDto.FeatureSliderID, values);
    }

    public async Task DeleteFeatureSliderAsync(string id)
    {
        await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderID == id);
    }

    public async Task FeatureSliderChageStatusToTrue(string id)
    {
        var values = await _featureSliderCollection.Find<FeatureSlider>(x => x.FeatureSliderID == id).FirstOrDefaultAsync();
        values.Status = true;
    }

    public async Task FeatureSliderChageStatusToFalse(string id)
    {
        var values = await _featureSliderCollection.Find<FeatureSlider>(x => x.FeatureSliderID == id).FirstOrDefaultAsync();
        values.Status = false;
    }
}
