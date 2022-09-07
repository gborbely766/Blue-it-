using Blue_it.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/questions", async () => await QuestionRepository.GetQuestionsAsync());
app.MapGet("/api/question/{questionId}", async (int questionId) => 
{
    Question question = await QuestionRepository.GetQuestionByIdAsync(questionId);
    if(question != null)
    {
        return Results.Ok(question);
    }
    else
    {
        return Results.BadRequest();
    }

});
app.MapPost("/api/add-new-question", async (Question questionToCreate) =>
{
    bool Successful = await QuestionRepository.AddNewQuestionAsync(questionToCreate);
    if (Successful)
    {
        return Results.Ok(questionToCreate);
    }
    else
    {
        return Results.BadRequest();
    }
});
app.MapPut("/api/update-question", async (Question question) =>
{
    bool Successful = await QuestionRepository.AddNewQuestionAsync(question);
    if (Successful)
    {
        return Results.Ok("Update Successful");
    }
    else
    {
        return Results.BadRequest();
    }
});

    

app.Run();

