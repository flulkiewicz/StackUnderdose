using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc.Routing;
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

    db.Answers.Add(newAnswer);
    await db.SaveChangesAsync();
});

app.MapPost("rateUserPost", async (StackUnderdoseContext db) =>
{
    var id = 6;
    var isThisAnswer = false;
    var isThisComment = false;
    var isThisQuestion = true;
    bool addScore = true;

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
    var itemToCommentId = 200;
    var userId = "B3C5717C-E363-4C14-CBBF-08DAD7D14528";
    var userInput = "No i cant?";
    var isThisAnswer = false;
    var isThisComment = true;
    var isThisQuestion = false;

    var newComment = new Comment
    {
        AuthorId = Guid.Parse(userId),
        Content= userInput,
    };

    if (isThisQuestion) newComment.QuestionId = itemToCommentId;
    else if (isThisAnswer) newComment.AnswerId = itemToCommentId;
    else if (isThisComment) newComment.ParentCommentId = itemToCommentId;

    db.Comments.Add(newComment);
    await db.SaveChangesAsync();
});

app.MapGet("topScore", async (StackUnderdoseContext db) =>
{
    var users = await db.Users
        .Include(x => x.Questions)
        .Include(x => x.Answers)
        .Include(x => x.Comments)
        
        .ToListAsync();

    int topScore = -999999999;
    Guid topUserId = new Guid();
     

    foreach(var user in users)
    {
        int scoreCount = 0;

        foreach (var question in user.Questions) scoreCount += question.Score;
        
        foreach (var answer in user.Answers) scoreCount += answer.Score;
        
        foreach (var comment in user.Comments) scoreCount += comment.Score;
        

        if (scoreCount > topScore)
        {
            topScore = scoreCount;
            topUserId = user.Id;
        }
    }

    var topUser = await db.Users.FirstAsync(x => x.Id == topUserId);

    var topUserDetails = new { Name = topUser.DisplayName, Score = topScore };


    return topUserDetails;
});

app.MapGet("mostAnswers", async (StackUnderdoseContext db) =>
{
    var answers = await db.Answers
    .GroupBy(x => x.QuestionId)
    .ToListAsync();

    return answers;

});


app.Run();

