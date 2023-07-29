using planta_api.Context;
using PlantaApi.Model;
using PlantaApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
PlantaRepository plantaRepository = new PlantaRepository(builder.Configuration);



var app = builder.Build();

app.MapGet("/planta", () => {
    return plantaRepository.FindAll().ToList();
});

app.MapPost("/planta/regar/{id}", (PlantaModel plantaModel) => {
    plantaRepository.Regar(plantaModel.Id, plantaModel.DataUltimaRegagem);
});

app.MapGet("/planta/{id}", (int id) => {
    var result = plantaRepository.FindByID(id);
    if(result == null){
        return Results.NotFound(new {message = "Não foi encontrado"});
    };

    return Results.Ok(plantaRepository.FindByID(id));
});

app.MapPost("/planta", (PlantaModel plantaModel) => {
    plantaRepository.Add(plantaModel);
});

app.MapPut("/planta/{id}", (int id, PlantaModel plantaModel) => {
    plantaRepository.Update(plantaModel);
});

app.MapDelete("/planta/{id}", (int id) => {
    plantaRepository.Remove(id);
});

//WaitForDatabase.WaitFor(builder.Configuration);

app.Run();
