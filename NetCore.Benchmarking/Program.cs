// dotnet run -c Release -f net8.0 --runtimes net8.0 net9.0

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