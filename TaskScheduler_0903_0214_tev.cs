// 代码生成时间: 2025-09-03 02:14:08
// TaskScheduler.cs
// 定时任务调度器实现
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

// 定时任务调度器类
public class TaskScheduler
{
    private readonly Timer _timer;
    private readonly Action _task;
    private readonly TimeSpan _interval;
    private readonly string _taskName;

    public TaskScheduler(Action task, TimeSpan interval, string taskName)
    {
        _task = task ?? throw new ArgumentNullException(nameof(task));
        _interval = interval;
        _taskName = taskName;
        _timer = new Timer(ExecuteTask);
    }

    // 开始执行任务
    public void Start()
    {
        _timer.Interval = _interval.TotalMilliseconds;
        _timer.AutoReset = true;
        _timer.Start();
        Console.WriteLine($"定时任务 {_taskName} 已启动，每隔 {_interval.TotalSeconds} 秒执行一次。");
    }

    // 停止执行任务
    public void Stop()
    {
        _timer.Stop();
        Console.WriteLine($"定时任务 {_taskName} 已停止。");
    }

    private void ExecuteTask(object sender)
    {
        try
        {
            // 执行任务
            _task();
        }
        catch (Exception ex)
        {
            // 异常处理
            Console.WriteLine($"执行定时任务 {_taskName} 时发生错误：{ex.Message}");
        }
    }
}

// 程序入口
class Program
{
    static async Task Main(string[] args)
    {
        // 创建定时任务调度器实例
        var taskScheduler = new TaskScheduler(
            () => Console.WriteLine("执行定时任务..."),  // 要执行的任务
            TimeSpan.FromSeconds(5),  // 定时间隔
            "TestTask"  // 任务名称
        );

        // 启动任务
        taskScheduler.Start();

        // 等待用户输入以停止任务
        Console.WriteLine("按任意键停止任务...");
        await Task.Run(() => Console.ReadKey(true));
        taskScheduler.Stop();
    }
}