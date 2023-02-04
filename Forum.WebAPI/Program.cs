using Autofac;
using Autofac.Extensions.DependencyInjection;
using Forum;
using Forum.Model;
using Forum.Model.Common;
using Forum.Repository;
using Forum.Repository.Common;
using Forum.Service;
using Forum.Service.Common;
using Forum.Service.Helpers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterType<UserModel>().As<IUserModel>();
    builder.RegisterType<UserService>().As<IUserService>();
    builder.RegisterType<UserRepository>().As<IUserRepository>();
    builder.RegisterType<PostModel>().As<IPostModel>();
    builder.RegisterType<PostRepository>().As<IPostRepository>();
    builder.RegisterType<PostService>().As<IPostService>();
    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
    builder.RegisterType<FilterFacade>().As<IFilterFacade>();
    builder.RegisterType<ForumContext>();
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperProfiles)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();