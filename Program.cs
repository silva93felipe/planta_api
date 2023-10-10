
using planta_api.Context;
using planta_api.DTO;
using planta_api.Mapper;
using planta_api.Repositories;
using planta_api.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPlantaRepository, PlantaRepository>();
builder.Services.AddScoped<IRegagemRepository, RegagemRepository>();

//WaitForDatabase.WaitFor(builder.Configuration);

var app = builder.Build();

app.MapGet("/planta", (IPlantaRepository _plantaRepository) => {
    List<PlantaResponse> plantasRequest = new List<PlantaResponse>();
    return _plantaRepository.FindAll().ToList().Select(p => PlantaMapper.Mapper(p));
});

app.MapGet("/planta/{id}", (IPlantaRepository _plantaRepository, int id) => {
    var result = _plantaRepository.FindByID(id);
    if(result == null){
        return Results.NotFound(new {message = "Nenhuma planta encontrada."});
    };

    return Results.Ok(PlantaMapper.Mapper(result));
});

app.MapPost("/planta", (IPlantaRepository _plantaRepository, PlantaRequest plantaModel) => {
    _plantaRepository.Add(PlantaMapper.Mapper(plantaModel));
});

app.MapPut("/planta/{id}", (IPlantaRepository _plantaRepository, int id, PlantaRequest plantaModel) => {     
    _plantaRepository.Update(PlantaMapper.Mapper(plantaModel));
});

app.MapDelete("/planta/{id}", (IPlantaRepository _plantaRepository, int id) => {
    _plantaRepository.Remove(id);
});

app.MapPost("/planta/regar/{id}", (IRegagemRepository _regagemRepository, int id, PlantaRequest plantaModel) => {
    //_regagemRepository.Regar(id, plantaModel.UltimaRegagem);
});

app.Run();
