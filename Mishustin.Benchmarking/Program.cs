using BenchmarkDotNet.Running;
using Mishustin.Benchmarking.DateTime;

namespace Mishustin.Benchmarking
{
	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<Now>();
		}
	}
}
