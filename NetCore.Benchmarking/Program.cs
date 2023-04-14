using BenchmarkDotNet.Running;

namespace NetCore.Benchmarking
{
	internal class Program
	{
		static void Main(string[] args)
		{
			BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
		}
	}
}