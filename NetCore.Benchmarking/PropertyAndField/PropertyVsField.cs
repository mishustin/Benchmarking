using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace NetCore.Benchmarking.PropertyAndField
{
	[SimpleJob(RuntimeMoniker.Net48)]
	public class PropertyVsField
	{
		//int
		private readonly Random _random = new Random();
		private readonly TestModel _getIntPropertyModel = new TestModel();
		private readonly TestModel _setIntPropertyModel = new TestModel();
		private readonly TestModel _getIntFieldModel = new TestModel();
		private readonly TestModel _setIntFieldModel = new TestModel();

		//string
		private readonly TestModel _getStringPropertyModel = new TestModel();
		private readonly TestModel _setStringPropertyModel = new TestModel();
		private readonly TestModel _getStringFieldModel = new TestModel();
		private readonly TestModel _setStringFieldModel = new TestModel();

		[Params(10_000, 100_000, 1_000_000)]
		public int N { get; set; }

		[Benchmark]
		public void GetIntProperty()
		{
			for (int i = 0; i < N; i++)
			{
				var r = _getIntPropertyModel.IntProperty;
			}
		}

		[Benchmark]
		public void SetIntProperty()
		{
			for (int i = 0; i < N; i++)
			{
				_setIntPropertyModel.IntProperty = _random.Next(N);
			}
		}

		[Benchmark]
		public void GetIntField()
		{
			for (int i = 0; i < N; i++)
			{
				var r = _getIntFieldModel.IntField;
			}
		}

		[Benchmark]
		public void SetIntField()
		{
			for (int i = 0; i < N; i++)
			{
				_setIntFieldModel.IntField = _random.Next(N);
			}
		}

		[Benchmark]
		public void GetStringProperty()
		{
			for (int i = 0; i < N; i++)
			{
				var r = _getStringPropertyModel.StringProperty;
			}
		}

		[Benchmark]
		public void SetStringProperty()
		{
			for (int i = 0; i < N; i++)
			{
				_setStringPropertyModel.StringProperty = Guid.NewGuid().ToString();
			}
		}

		[Benchmark]
		public void GetStringField()
		{
			for (int i = 0; i < N; i++)
			{
				var r = _getStringFieldModel.StringField;
			}
		}

		[Benchmark]
		public void SetStringField()
		{
			for (int i = 0; i < N; i++)
			{
				_setStringFieldModel.StringField = Guid.NewGuid().ToString();
			}
		}
	}

	public class TestModel
	{
		public int IntProperty { get; set; }
		public int IntField;

		public string StringProperty { get; set; } = "12345";
		public string StringField = "12345";
	}
}
