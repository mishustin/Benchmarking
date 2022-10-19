using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace NetCore.Benchmarking.DateTime
{
	[SimpleJob(RuntimeMoniker.HostProcess)]
	public class Now
	{
		private readonly System.DateTime _time = new(2019, 09, 08);

		[Benchmark]
		public void DateTimeNow()
		{
			var r = System.DateTime.Now;
		}

		[Benchmark]
		public void DateTimeUtcNow()
		{
			var r = System.DateTime.UtcNow;
		}

		[Benchmark]
		public void TimeSpan()
		{
			var t1 = Stopwatch.GetTimestamp();
			var t2 = Stopwatch.GetTimestamp();
			var r1 = (t2 - t1) / Stopwatch.Frequency;
			var r2 = _time.AddSeconds(r1);
		}
	}
}