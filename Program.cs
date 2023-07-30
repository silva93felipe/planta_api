using planta_api.DTO;
using planta_api.Mapper;
using PlantaApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
PlantaRepository plantaRepository = new PlantaRepository(builder.Configuration);

var app = builder.Build();

app.MapGet("/planta", () => {
    List<PlantaRequest> plantasRequest = new List<PlantaRequest>();
    var plantasModel  = plantaRepository.FindAll().ToList();
    foreach (var pla in plantasModel)
    {
        plantasRequest.Add(PlantaRequestMapper.PlantaDto(pla));
    }

    return plantasRequest;
});

app.MapPost("/planta/regar/{id}", (PlantaRequest plantaModel) => {
    plantaRepository.Regar(plantaModel.Id, plantaModel.DataUltimaRegagem);
});

app.MapGet("/planta/{id}", (int id) => {
    var result = plantaRepository.FindByID(id);
    if(result == null){
        return Results.NotFound(new {message = "Nenhuma planta encontrada."});
    };

    var planta = PlantaRequestMapper.PlantaDto(result);

    return Results.Ok(planta);
});

app.MapPost("/planta", (PlantaRequest plantaModel) => {
    var planta = PlantaRequestMapper.PlantaDto(plantaModel);
    plantaRepository.Add(planta);
});

app.MapPut("/planta/{id}", (int id, PlantaRequest plantaModel) => {
     var planta = PlantaRequestMapper.PlantaDto(plantaModel);
    plantaRepository.Update(planta);
});

app.MapDelete("/planta/{id}", (int id) => {
    plantaRepository.Remove(id);
});

//WaitForDatabase.WaitFor(builder.Configuration);

app.Run();
