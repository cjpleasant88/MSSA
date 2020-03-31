using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

	class DisposableWrapper : IDisposable
	{
		private bool disposed = false;
		public DisposableWrapper(IDisposable param)
		{
			IDisposable data = param;
		}

		~DisposableWrapper()
		{
			this.Dispose();
		}

		public void Dispose()
		{
			lock (this)
			{
				if (!this.disposed)
				{
					Console.WriteLine("This item is being disposed");
				}
				this.disposed = true;
				GC.SuppressFinalize(this);
			}
		}
	}
}