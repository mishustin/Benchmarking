using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Mishustin.Benchmarking.TaskAndValueTask
{
	[MemoryDiagnoser]
	[SimpleJob(RuntimeMoniker.Net48)]
	public class TaskVsValueTask
	{
		[Params(100, 1000)]
		public int N { get; set; }

		[Benchmark]
		public void TaskMethod()
		{
			for (var i = 0; i < N; i++)
			{
				var r = TestTask();
			}
		}

		[Benchmark]
		public async Task TaskMethodAsync()
		{
			for (var i = 0; i < N; i++)
			{
				var r = await TestTask();
			}
		}

		[Benchmark]
		public void ValueTaskMethod()
		{
			for (var i = 0; i < N; i++)
			{
				var r = TestValueTask();
			}
		}

		[Benchmark]
		public async Task ValueTaskMethodAsync()
		{
			for (var i = 0; i < N; i++)
			{
				var r = await TestValueTask();
			}
		}

		[Benchmark]
		public void ValueTaskAsTaskMethod()
		{
			for (var i = 0; i < N; i++)
			{
				var r = TestValueTask().AsTask();
			}
		}

		[Benchmark]
		public async Task ValueTaskAsTaskMethodAsync()
		{
			for (var i = 0; i < N; i++)
			{
				var r = await TestValueTask().AsTask();
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
