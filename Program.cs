using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using StackUnderdose.Entities;
using StackUnderdose.Seeders;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddDbContext<StackUnderdoseContext>(
        option => option.UseSqlServer(builder.Configuration.GetConnectionString("StackUnderdoseConnectionString"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<StackUnderdoseContext>();

Seeder.Seed(dbContext);

app.MapPost("createQuestion", async (StackUnderdoseContext db) => 
{
    var userInput = new
    {
        Title = "How can i add entity?",
        Description = "I dont know how can i add entities, can someone help? Plz.",
        Tags = new List<Tag>()
        {
            new Tag{Value = "PHP" },
            new Tag{Value = "Laravel" }
        }
    };

    var userId = "B3C5717C-E363-4C14-CBBF-08DAD7D14528";

    var newQuestion = new Question()
    {
        Title = userInput.Title,
        Description = userInput.Description,
        Tags = userInput.Tags,
        AuthorId = Guid.Parse(userId)
    };

    db.Questions.Add(newQuestion);
    await db.SaveChangesAsync();
});

app.MapPost("addAnswer", async (StackUnderdoseContext db) =>
{
    var questionId = 34;
    var userInput = "Please, use search option and stop embarassing yourself...";
    var userId = "631AE3C2-C1C4-49DA-CBC2-08DAD7D14528";


    var newAnswer = new Answer()
    {
        Content = userInput,
        AuthorId= Guid.Parse(userId),
        QuestionId= questionId,
    };

});

app.MapPost("rateUserPost", async (StackUnderdoseContext db) =>
{
    var id = 4;
    var isThisAnswer = false;
    var isThisComment = true;
    var isThisQuestion = false;
    bool addScore = false;

    if (isThisAnswer)
    {
        var answer = db.Answers.First(x => x.Id == id);

        if (addScore) answer.Score++;
        else answer.Score--;
    }
    else if (isThisComment) 
    {
        var comment = db.Comments.First(x => x.Id == id);

        if (addScore) comment.Score++;
        else comment.Score--;
    }
    else if (isThisQuestion)
    {
        var question = db.Questions.First(x => x.Id == id);

        if (addScore) question.Score++;
        else question.Score--;
    }

    await db.SaveChangesAsync();
});

app.MapPost("addComment", async (StackUnderdoseContext db) =>
{


});



app.Run();

