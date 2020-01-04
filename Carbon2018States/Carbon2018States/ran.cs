namespace System
{
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
			if (max < min)
				throw new Exception("Argument max must be greater than min.");
			
			return (int)Math.Floor(seed.NextDouble() * (max - min + 1) + min);
		}

	}
}
