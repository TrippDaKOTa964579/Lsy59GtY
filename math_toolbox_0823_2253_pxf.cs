// 代码生成时间: 2025-08-23 22:53:45
using System;
using System.Collections.Generic;
# TODO: 优化性能

namespace MathToolbox
{
    // MathToolbox 提供一系列数学计算功能
    public class MathToolbox
# 扩展功能模块
    {
        // 计算两个数的和
        public double Add(double number1, double number2)
# TODO: 优化性能
        {
            return number1 + number2;
        }

        // 计算两个数的差
        public double Subtract(double number1, double number2)
# 扩展功能模块
        {
            return number1 - number2;
        }

        // 计算两个数的乘积
# 添加错误处理
        public double Multiply(double number1, double number2)
        {
            return number1 * number2;
# 优化算法效率
        }

        // 计算两个数的商
        public double Divide(double number1, double number2)
        {
            // 错误处理：除数不能为0
            if (number2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return number1 / number2;
        }

        // 计算一个数的平方根
        public double SquareRoot(double number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Cannot calculate the square root of a negative number.");
            }
            return Math.Sqrt(number);
# 扩展功能模块
        }

        // 计算一个数的幂
# 添加错误处理
        public double Power(double number, double exponent)
        {
            return Math.Pow(number, exponent);
        }
    }

    // 程序入口点
    class Program
# 添加错误处理
    {
        static void Main(string[] args)
        {
            MathToolbox toolbox = new MathToolbox();

            // 测试加法
            Console.WriteLine("Addition: 5 + 3 = " + toolbox.Add(5, 3));

            // 测试减法
            Console.WriteLine("Subtraction: 5 - 3 = " + toolbox.Subtract(5, 3));

            // 测试乘法
            Console.WriteLine("Multiplication: 5 * 3 = " + toolbox.Multiply(5, 3));

            // 测试除法
            try
            {
                Console.WriteLine("Division: 5 / 3 = " + toolbox.Divide(5, 3));
                // 故意除以0来测试错误处理
                Console.WriteLine("Division: 5 / 0 = " + toolbox.Divide(5, 0));
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 测试平方根
            try
            {
                Console.WriteLine("Square Root: √9 = " + toolbox.SquareRoot(9));
# TODO: 优化性能
                // 故意计算负数的平方根来测试错误处理
                Console.WriteLine("Square Root: √-9 = " + toolbox.SquareRoot(-9));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}