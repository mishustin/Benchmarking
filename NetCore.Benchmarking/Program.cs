using BenchmarkDotNet.Running;
using NetCore.Benchmarking.DateTime;
using NetCore.Benchmarking.TaskAndValueTask;

namespace NetCore.Benchmarking
{
	internal class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<Now>();
		}
	}
}