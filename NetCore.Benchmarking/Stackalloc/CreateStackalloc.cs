using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace NetCore.Benchmarking.Stackalloc
{
	[MemoryDiagnoser]
	[ThreadingDiagnoser]
	[DisassemblyDiagnoser]
	[SimpleJob(RuntimeMoniker.HostProcess)]
	public class CreateStackalloc
	{
		[Params(1, 10, 100, 500)]
		public int N { get; set; }

		[Benchmark(Baseline = true, Description = "stack, bool")]
		public void CreateInStackBool()
		{
			Span<bool> array = stackalloc bool[N];
		}

		[Benchmark(Description = "stack, byte")]
		public void CreateInStackByte()
		{
			Span<byte> array = stackalloc byte[N];
		}

		[Benchmark(Description = "stack, int")]
		public void CreateInStackInt()
		{
			Span<int> array = stackalloc int[N];
		}

		[Benchmark(Description = "stack, long")]
		public void CreateInStackLong()
		{
			Span<long> array = stackalloc long[N];
		}

		[Benchmark(Description = "stack, double")]
		public void CreateInStackDouble()
		{
			Span<double> array = stackalloc double[N];
		}

		[Benchmark(Description = "heap, bool")]
		public void CreateInHeapBool()
		{
			Span<bool> array = new bool[N];
		}

		[Benchmark(Description = "heap, byte")]
		public void CreateInHeapByte()
		{
			Span<byte> array = new byte[N];
		}

		[Benchmark(Description = "heap, int")]
		public void CreateInHeapInt()
		{
			Span<int> array = new int[N];
		}

		[Benchmark(Description = "heap, long")]
		public void CreateInHeapLong()
		{
			Span<long> array = new long[N];
		}

		[Benchmark(Description = "heap, double")]
		public void CreateInHeapDouble()
		{
			Span<double> array = new double[N];
		}
	}
}