using BenchmarkDotNet.Running;
using Mishustin.Benchmarking.PropertyAndField;

namespace Mishustin.Benchmarking
{
	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<PropertyVsField>();
		}
	}
}
