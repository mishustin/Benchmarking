using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace NetCore.Benchmarking.TaskAndValueTask
{
	[MemoryDiagnoser]
	[SimpleJob(RuntimeMoniker.Net48)]
	public class TaskVsValueTask
	{
		[Params(50, 100)]
		public int N { get; set; }

		[Benchmark(Description = "Task Await", Baseline = true)]
		public async Task TaskMethodAsync()
		{
			for (var i = 0; i < N; i++)
			{
				var r = await TestTask();
			}
		}

		[Benchmark(Description = "ValueTask Await")]
		public async Task ValueTaskMethodAsync()
		{
			for (var i = 0; i < N; i++)
			{
				var r = await TestValueTask();
			}
		}

		[Benchmark(Description = "ValueTask AsTask Await")]
		public async Task ValueTaskAsTaskMethodAsync()
		{
			for (var i = 0; i < N; i++)
			{
				var r = await TestValueTask().AsTask();
			}
		}

		[Benchmark(Description = "ValueTask Preserve Await")]
		public async Task ValueTaskPreserveMethodAsync()
		{
			for (var i = 0; i < N; i++)
			{
				var r = await TestValueTask().Preserve();
			}
		}

		private Task<int> TestTask()
		{
			return Task.FromResult(123);
		}

		private ValueTask<int> TestValueTask()
		{
			return new ValueTask<int>(123);
		}
	}
}
