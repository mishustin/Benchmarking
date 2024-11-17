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
			var now = System.DateTime.Now;
		}

		[Benchmark]
		public void DateTimeUtcNow()
		{
			var now = System.DateTime.UtcNow;
		}

		[Benchmark]
		public void TimeSpan()
		{
			var time1 = Stopwatch.GetTimestamp();
			var time2 = Stopwatch.GetTimestamp();
			var span = (time2 - time1) / Stopwatch.Frequency;
			var time = _time.AddSeconds(span);
		}
	}
}