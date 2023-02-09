using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace NetFramework.Benchmarking
{
	[MemoryDiagnoser]
	[DisassemblyDiagnoser]
	[SimpleJob(RuntimeMoniker.HostProcess)]
	public class ConfigurationManagerVsEmpty
	{
		[Params(10000)]
		public int N { get; set; }

		[Benchmark]
		public void ConfigurationManager()
		{
			for (var i = 0; i < N; i++)
			{
				var config = System.Configuration.ConfigurationManager.AppSettings["someConfig"];
			}
		}

		[Benchmark(Baseline = true)]
		public void Empty()
		{
			for (var i = 0; i < N; i++)
			{
				
			}
		}
	}
}
