// 代码生成时间: 2025-09-15 05:19:03
using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

// 数据库连接池管理器
public class DatabaseConnectionPoolManager
{
    // 并发字典用于存储连接池
    private ConcurrentDictionary<string, ConcurrentBag<DbConnection>> connectionPoolDictionary;
    // 锁对象
    private readonly object lockObject = new object();

    // 构造函数
    public DatabaseConnectionPoolManager()
    {
        connectionPoolDictionary = new ConcurrentDictionary<string, ConcurrentBag<DbConnection>>();
    }

    // 获取数据库连接
    public DbConnection GetConnection(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException("Connection string cannot be null or whitespace.");
        }

        // 尝试从连接池中获取连接
        if (connectionPoolDictionary.TryGetValue(connectionString, out var connectionBag))
        {
            return GetAvailableConnection(connectionBag);
        }
        else
        {
            // 如果没有找到，创建一个新连接并添加到连接池
            return CreateAndAddNewConnection(connectionString);
        }
    }

    // 创建一个新连接并添加到连接池
    private DbConnection CreateAndAddNewConnection(string connectionString)
    {
        lock (lockObject)
        {
            DbConnection newConnection = CreateConnection(connectionString);
            AddConnectionToPool(connectionString, newConnection);
            return newConnection;
        }
    }

    // 创建数据库连接
    private DbConnection CreateConnection(string connectionString)
    {
        // 这里假设使用SQL Server作为数据库
        // 可以根据需要替换为其他数据库连接
        return new System.Data.SqlClient.SqlConnection(connectionString);
    }

    // 添加连接到连接池
    private void AddConnectionToPool(string connectionString, DbConnection connection)
    {        
        if (!connectionPoolDictionary.ContainsKey(connectionString))
        {
            connectionPoolDictionary.TryAdd(connectionString, new ConcurrentBag<DbConnection>());
        }
        connectionPoolDictionary[connectionString].Add(connection);
    }

    // 从连接池中获取可用连接
    private DbConnection GetAvailableConnection(ConcurrentBag<DbConnection> connectionBag)
    {
        DbConnection availableConnection = null;
        while (connectionBag.TryTake(out availableConnection) && availableConnection == null)
        {
            if (availableConnection.State != ConnectionState.Open)
            {
                availableConnection.Dispose();
                availableConnection = null;
            }
        }
        return availableConnection;
    }

    // 释放数据库连接
    public void ReleaseConnection(string connectionString, DbConnection connection)
    {
        if (string.IsNullOrWhiteSpace(connectionString) || connection == null)
        {
            throw new ArgumentException("Connection string or connection cannot be null or whitespace.");
        }

        // 将连接返回到连接池
        if (connectionPoolDictionary.TryGetValue(connectionString, out var connectionBag))
        {
            connectionBag.Add(connection);
            connection.Close();
        }
        else
        {
            // 如果连接池中没有对应的连接，则释放连接
            connection.Dispose();
        }
    }
}
