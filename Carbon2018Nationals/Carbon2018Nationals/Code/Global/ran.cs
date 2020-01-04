namespace System
{

	/// <summary>
	/// ran.dom()
	/// </summary>
	public class ran
	{

		static protected Random seed = new Random();

		/// <summary>
		/// Generates a random interger between min and max.
		/// </summary>
		/// <param name="max">The max value.</param>
		/// <param name="min">The min value.</param>
		static public int dom(int max = 1, int min = 0)
		{
			return (int)Math.Floor(seed.NextDouble() * (max - min + 1) + min);
		}

		static public long dom(long max = 1, long min = 0)
		{
			return (long)Math.Floor(seed.NextDouble() * (max - min + 1) + min);
		}

	}

}
