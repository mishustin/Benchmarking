using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Mishustin.Benchmarking.TaskAndValueTask
{
	[MemoryDiagnoser]
	[SimpleJob(RuntimeMoniker.Net48)]
	public class TaskVsValueTask
	{
		[Params(10, 100 , 1000)]
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
		public void ValueTaskMethod()
		{
			for (var i = 0; i < N; i++)
			{
				var r = TestValueTask();
			}
		}

		private Task<Model> TestTask()
		{
			return Task.FromResult(new Model{Prop1 = "123"});
		}

		private ValueTask<Model> TestValueTask()
		{
			return new ValueTask<Model>(new Model{Prop1 = "123"});
		}
	}

	class Model
	{
		public string Prop1 { get; set; }
	}
}
