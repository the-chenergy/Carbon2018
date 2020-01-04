using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carboutil
{

	public class Carbostopwatch
	{

		/// ########################## PUBLIC PROPERTIES ############################



		/// ######################### PRIVATE PROPERTIES ############################

		static protected Dictionary<object, long> timeDict = new Dictionary<object, long>();

		/// ########################### PUBLIC METHODS ##############################

		static public long Reset(object target)
		{
			return (timeDict[target] = DateTimeOffset.Now.ToUnixTimeMilliseconds());
		}

		static public long MilliElapsed(object target)
		{
			return (timeDict.ContainsKey(target) ? DateTimeOffset.Now.ToUnixTimeMilliseconds() - timeDict[target] : long.MaxValue);
		}

		/// ########################### PRIVATE METHODS #############################



	}

}
