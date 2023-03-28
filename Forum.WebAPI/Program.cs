using Autofac;
using Autofac.Extensions.DependencyInjection;
using Forum;
using Forum.Model;
using Forum.Model.Comment;
using Forum.Model.Common;
using Forum.Model.Common.Comment;
using Forum.Model.Common.Post;
using Forum.Model.Common.Reaction;
using Forum.Model.Common.Role;
using Forum.Model.Common.User;
using Forum.Model.Post;
using Forum.Model.Reaction;
using Forum.Model.RoleModel;
using Forum.Model.User;
using Forum.Repository;
using Forum.Repository.Comment;
using Forum.Repository.Common;
using Forum.Repository.Common.Comment;
using Forum.Repository.Common.Post;
using Forum.Repository.Common.Reaction;
using Forum.Repository.Common.Role;
using Forum.Repository.Common.User;
using Forum.Repository.Post;
using Forum.Repository.Reaction;
using Forum.Repository.Role;
using Forum.Repository.User;
using Forum.Service.Common.Comment;
using Forum.Service.Common.Post;
using Forum.Service.Common.Reaction;
using Forum.Service.Common.Role;
using Forum.Service.Common.User;
using Forum.Service.Helpers;
using Forum.Service.Post;
using Forum.Service.Reaction;
using Forum.Service.Role;
using Forum.Service.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterType<UserModel>().As<IUserModel>();
    builder.RegisterType<UserRepository>().As<IUserRepository>();
    builder.RegisterType<UserService>().As<IUserService>();

    builder.RegisterType<PostModel>().As<IPostModel>();
    builder.RegisterType<PostRepository>().As<IPostRepository>();
    builder.RegisterType<PostService>().As<IPostService>();

    builder.RegisterType<CommentModel>().As<ICommentModel>();
    builder.RegisterType<CommentRepository>().As<ICommentRepository>();
    builder.RegisterType<CommentService>().As<ICommentService>();

    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
    builder.RegisterType<Paging>().As<IPaging>();
    builder.RegisterGeneric(typeof(PagedResult<>)).As(typeof(IPagedResult<>));

    builder.RegisterType<RoleModel>().As<IRoleModel>();
    builder.RegisterType<RoleRepository>().As<IRoleRepository>();
    builder.RegisterType<RoleService>().As<IRoleService>();

    builder.RegisterType<ReactionModel>().As<IReactionModel>();
    builder.RegisterType<ReactionRepository>().As<IReactionRepository>();
    builder.RegisterType<ReactionService>().As<IReactionService>();

    builder.RegisterType<ForumContext>();
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperProfiles)));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    Environment.SetEnvironmentVariable("SECRET", "SBudgetForumSecretKey");
    var secretKey = Environment.GetEnvironmentVariable("SECRET");
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});
builder.Services.Configure<IISOptions>(options =>
{
});
builder.Host.ConfigureAppConfiguration(config =>
{
    config.AddJsonFile("appsettings.json");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(
    builder =>
       builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();