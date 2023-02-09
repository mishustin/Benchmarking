using System.Configuration;
using System.Diagnostics;
using BenchmarkDotNet.Running;

namespace NetFramework.Benchmarking
{
	internal class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<ConfigurationManagerVsEmpty>();
		}
	}
}
