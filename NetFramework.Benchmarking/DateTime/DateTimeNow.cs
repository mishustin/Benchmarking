using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace NetFramework.Benchmarking.DateTime
{
	[SimpleJob(RuntimeMoniker.Net48)]
	public class Now
	{
		private System.DateTime _time = new System.DateTime(2019, 09, 08);

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