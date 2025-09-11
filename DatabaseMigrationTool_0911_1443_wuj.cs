// 代码生成时间: 2025-09-11 14:43:18
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage;
using System.IO;
using System.Reflection;

// DatabaseMigrationTool 类提供了数据库迁移的功能
public class DatabaseMigrationTool
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger _logger;

    // 构造函数注入 ServiceProvider 和 ILogger
    public DatabaseMigrationTool(IServiceProvider serviceProvider, ILogger logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    // 执行数据库迁移的方法
    public void MigrateDatabase<TContext>(string connectionString) where TContext : DbContext
    {
        try
        {
            // 构建 DbContextOptionsBuilder
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // 使用 ServiceProvider 获取 DbContext 实例
            using (var context = _serviceProvider.GetRequiredService<TContext>())
            {
                // 应用迁移
                context.Database.Migrate();
                _logger.LogInformation("Database migration completed successfully.");
            }
        }
        catch (Exception ex)
        {
            // 错误处理
            _logger.LogError(ex, "An error occurred during database migration.");
            throw;
        }
    }
}

// DatabaseMigrationToolFactory 类用于创建 DatabaseMigrationTool 的实例
public class DatabaseMigrationToolFactory : IDesignTimeDbContextFactory<DbContext>
{
    private readonly string _connectionString;

    // 构造函数接收数据库连接字符串
    public DatabaseMigrationToolFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    // 创建 DbContext 实例
    public DbContext CreateDbContext(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging(logging => logging.AddConsole())
            .AddDbContext<DbContext>(options =>
                options.UseSqlServer(_connectionString))
            .BuildServiceProvider();

        return serviceProvider.GetService<DbContext>();
    }
}

// Program 类是程序的入口点
public class Program
{
    public static void Main(string[] args)
    {
        // 使用命令行参数获取数据库连接字符串
        var connectionString = args.Length > 0 ? args[0] : "Server=localhost;Database=myDb;Trusted_Connection=True;";

        // 创建 ServiceProvider
        var serviceProvider = new ServiceCollection()
            .AddLogging(logging => logging.AddConsole())
            .AddDbContext<YourDbContext>(options => options.UseSqlServer(connectionString))
            .BuildServiceProvider();

        // 创建 DatabaseMigrationTool 实例
        var migrationTool = new DatabaseMigrationTool(serviceProvider, serviceProvider.GetService<ILogger<Program>>());

        // 执行迁移
        migrationTool.MigrateDatabase<YourDbContext>(connectionString);
    }
}
