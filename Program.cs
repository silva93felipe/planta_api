using planta_api.Context;
using planta_api.DTO;
using planta_api.Mapper;
using planta_api.Repositories;
using PlantaApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
PlantaRepository plantaRepository = new PlantaRepository(builder.Configuration);
RegagemRepository regagemRepository = new RegagemRepository(builder.Configuration);

var app = builder.Build();

app.MapGet("/planta", () => {
    List<PlantaResponse> plantasRequest = new List<PlantaResponse>();
    return plantaRepository.FindAll().ToList().Select(p => PlantaMapper.Mapper(p));
});

app.MapGet("/planta/{id}", (int id) => {
    var result = plantaRepository.FindByID(id);
    if(result == null){
        return Results.NotFound(new {message = "Nenhuma planta encontrada."});
    };

    return Results.Ok(PlantaMapper.Mapper(result));
});

app.MapPost("/planta", (PlantaRequest plantaModel) => {
    plantaRepository.Add(PlantaMapper.Mapper(plantaModel));
});

app.MapPut("/planta/{id}", (int id, PlantaRequest plantaModel) => {     
    plantaRepository.Update(PlantaMapper.Mapper(plantaModel));
});

app.MapDelete("/planta/{id}", (int id) => {
    plantaRepository.Remove(id);
});

app.MapPost("/planta/regar/{id}", (PlantaRequest plantaModel) => {
    regagemRepository.Regar(plantaModel.Id, plantaModel.UltimaRegagem);
});

WaitForDatabase.WaitFor(builder.Configuration);

app.Run();
