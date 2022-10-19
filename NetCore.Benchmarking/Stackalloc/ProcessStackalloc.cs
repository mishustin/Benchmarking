using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace NetCore.Benchmarking.Stackalloc
{
	[MemoryDiagnoser]
	[SimpleJob(RuntimeMoniker.HostProcess)]
	public class ProcessStackalloc
	{
		[Params(1, 10, 100, 500)]
		public int N { get; set; }

		[Benchmark(Baseline = true)]
		public void ProcessInStack()
		{
			//todo подумать как не учитывать создание в замере
			Span<int> array = stackalloc int[N];
			for (var i = 0; i < array.Length; i++)
			{
				var r = array[i];
			}
		}

		[Benchmark]
		public void ProcessInHeap()
		{
			var array = new int[N];
			for (var i = 0; i < array.Length; i++)
			{
				var r = array[i];
			}
		}
	}
}