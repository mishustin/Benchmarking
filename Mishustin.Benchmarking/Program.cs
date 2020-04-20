using BenchmarkDotNet.Running;
using Mishustin.Benchmarking.TaskAndValueTask;

namespace Mishustin.Benchmarking
{
	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<TaskVsValueTask>();
		}
	}
}
