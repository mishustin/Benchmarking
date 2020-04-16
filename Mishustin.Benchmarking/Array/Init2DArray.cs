using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Mishustin.Benchmarking.Array
{
	[SimpleJob(RuntimeMoniker.Net48)]
	public class Init2DArray
	{
		[Params(10, 100, 1000)]
		public int N { get; set; }

		[Params(400)]
		public int M { get; set; }

		[Params(1, 5, 10, 20)]
		public int ForCount { get; set; }

		[Benchmark]
		public void Array()
		{
			var arr = new double[M, N];
			for (int k = 0; k < ForCount; k++)
			{
				for (int i = 0; i < M; i++)
				{
					for (int j = 0; j < N; j++)
					{
						arr[i, j] += 1;
					}
				}
			}
		}

		[Benchmark]
		public void ArrayOfArray()
		{
			var arr = new double[M][];
			for (int i = 0; i < M; i++)
			{
				arr[i] = new double[N];
			}

			for (int k = 0; k < ForCount; k++)
			{
				for (int i = 0; i < M; i++)
				{
					for (int j = 0; j < N; j++)
					{
						arr[i][j] += 1;
					}
				}
			}
		}
	}
}