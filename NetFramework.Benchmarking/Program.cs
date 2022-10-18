using BenchmarkDotNet.Running;
using NetFramework.Benchmarking.TaskAndValueTask;

namespace NetFramework.Benchmarking
{
	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<TaskVsValueTask>();
		}
	}
}
