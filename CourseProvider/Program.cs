using CourserProvider.Infrastructure.Data.Contexts;
using CourserProvider.Infrastructure.GraphQL.Mutations;
using CourserProvider.Infrastructure.GraphQL.ObjectTypes;
using CourserProvider.Infrastructure.GraphQL.Queries;
using CourserProvider.Infrastructure.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddPooledDbContextFactory<DataContext>(x =>
        {
            x.UseCosmos(Environment.GetEnvironmentVariable("COSMOS_URI")!, Environment.GetEnvironmentVariable("COSMOS_DBNAME")!)
            .UseLazyLoadingProxies();

        });

        services.AddScoped<ICourseService, CourseService>();


        services.AddGraphQLFunction()
                .AddQueryType<CourseQuery>()
                .AddMutationType<CourseMutation>()
                .AddType<CourseType>();


        var sp = services.BuildServiceProvider();
        using var scope = sp.CreateScope();
        var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DataContext>>();
        using var content = dbContextFactory.CreateDbContext();
        content.Database.EnsureCreated();

    })
    .Build();

host.Run();
