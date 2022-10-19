using BenchmarkDotNet.Running;
using NetCore.Benchmarking.DateTime;
using NetCore.Benchmarking.Stackalloc;
using NetCore.Benchmarking.TaskAndValueTask;

namespace NetCore.Benchmarking
{
	internal class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<CreateStackalloc>();
		}
	}
}