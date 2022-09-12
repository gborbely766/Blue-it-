using Blue_it.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder =>
    {
        builder.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:3000");
    });
});
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

app.UseCors("CORSPolicy");

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
app.MapGet("/api/answers/{questionId}", async (int questionId) => await AnswerRepository.GetAnswersForQuestionAsync(questionId));
app.MapPost("/api/add-new-answer", async (Answer answerToCreate) =>
{
    bool Successful = await AnswerRepository.AddNewAnswerAsync(answerToCreate);
    if (Successful)
    {
        return Results.Ok(answerToCreate);
    }
    else
    {
        return Results.BadRequest();
    }
});
app.MapPut("/api/update-answer", async (Answer answer) =>
{
    bool Successful = await AnswerRepository.UpdateAnswerAsync(answer);
    if (Successful)
    {
        return Results.Ok("Update Successful");
    }
    else
    {
        return Results.BadRequest();
    }
});
app.MapDelete("/api/delete-question/{questionId}", async (int questionId) =>
{
    bool Successful = await QuestionRepository.DeleteQuestionAsync(questionId);
    if (Successful)
    {
        return Results.Ok("Delete Successful");
    }
    else
    {
        return Results.BadRequest();
    }
});
app.MapDelete("/api/delete-answer/{answerId}", async (int answerId) =>
{
    bool Successful = await AnswerRepository.DeleteAnswerAsync(answerId);
    if (Successful)
    {
        return Results.Ok("Delete Successful");
    }
    else
    {
        return Results.BadRequest();
    }
});
app.MapDelete("/api/delete-comment/{commentId}", async (int commentId) =>
{
    bool Successful = await CommentRepository.DeleteCommentAsync(commentId);
    if (Successful)
    {
        return Results.Ok("Delete Successful");
    }
    else
    {
        return Results.BadRequest();
    }
});
app.MapPost("/api/add-new-comment", async (Comment commentToCreate) =>
{
    bool Successful = await CommentRepository.AddNewCommentAsync(commentToCreate);
    if (Successful)
    {
        return Results.Ok(commentToCreate);
    }
    else
    {
        return Results.BadRequest();
    }
});
app.MapGet("/api/comment/{answerId}", async (int answerId) =>
{
    List<Comment> comments = await CommentRepository.GetCommentsForAnswerAsync(answerId);
});
app.MapPut("/api/update-comment", async (Comment comment) =>
{
    bool Successful = await CommentRepository.UpdateCommentAsync(comment);
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

