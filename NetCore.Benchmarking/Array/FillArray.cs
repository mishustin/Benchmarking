using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace NetCore.Benchmarking.Array
{
	[SimpleJob(RuntimeMoniker.HostProcess)]
	public class FillArray
	{
		[Params(100, 1000, 5000)]
		public int N { get; set; }

		public Model[] Input { get; set; }
		public double[,] Output { get; set; }
		public double[][] OutputArrayOfArray { get; set; }

		[GlobalSetup]
		public void GlobalSetup()
		{
			var m = 100;

			Input = new[]
			{
				new Model(m, N, 0, 99),
				new Model(m, N, 100, 199),
				new Model(m, N, 200, 299),
				new Model(m, N, 300, 399)
			};

			Output = new double[400, N];

			OutputArrayOfArray = new double[400][];
		}

		[Benchmark]
		public void Sequentially()
		{
			for (var i = Input[0].From; i <= Input[0].To; i++)
			{
				for (var j = 0; j < N; j++)
				{
					Output[i, j] = Input[0].Array[i - Input[0].From, j];
				}
			}

			for (var i = Input[1].From; i <= Input[1].To; i++)
			{
				for (var j = 0; j < N; j++)
				{
					Output[i, j] = Input[1].Array[i - Input[1].From, j];
				}
			}

			for (var i = Input[2].From; i <= Input[2].To; i++)
			{
				for (var j = 0; j < N; j++)
				{
					Output[i, j] = Input[2].Array[i - Input[2].From, j];
				}
			}

			for (var i = Input[3].From; i <= Input[3].To; i++)
			{
				for (var j = 0; j < N; j++)
				{
					Output[i, j] = Input[3].Array[i - Input[3].From, j];
				}
			}
		}

		[Benchmark]
		public void ConcurrentlyFor()
		{
			Parallel.For(0, 4, ind =>
			{
				for (var i = Input[ind].From; i <= Input[ind].To; i++)
				{
					for (var j = 0; j < N; j++)
					{
						Output[i, j] = Input[ind].Array[i - Input[ind].From, j];
					}
				}
			});
		}

		[Benchmark]
		public void ConcurrentlyForEach()
		{
			Parallel.ForEach(Input, model =>
			{
				for (var i = model.From; i <= model.To; i++)
				{
					for (var j = 0; j < N; j++)
					{
						Output[i, j] = model.Array[i - model.From, j];
					}
				}
			});
		}

		[Benchmark]
		public void ConcurrentlyForEachArrayOfArray()
		{
			for (int i = 0; i < 400; i++)
			{
				OutputArrayOfArray[i] = new double[N];
			}
			Parallel.ForEach(Input, model =>
			{
				for (var i = model.From; i <= model.To; i++)
				{
					for (var j = 0; j < N; j++)
					{
						OutputArrayOfArray[i][j] = model.ArrayOfArray[i - model.From][j];
					}
				}
			});
		}
	}

	public class Model
	{
		public Model(int m, int n, int from, int to)
		{
			From = from;
			To = to;

			Array = new double[m, n];
			ArrayOfArray = new double[m][];
			for (var i = 0; i < m; i++)
			{
				ArrayOfArray[i] = new double[n];
				for (var j = 0; j < n; j++)
				{
					Array[i, j] = to;
					ArrayOfArray[i][j] = to;
				}
			}
		}

		public double[,] Array { get; }
		public double[][] ArrayOfArray { get; }
		public int From { get; }
		public int To { get; }
	}

}