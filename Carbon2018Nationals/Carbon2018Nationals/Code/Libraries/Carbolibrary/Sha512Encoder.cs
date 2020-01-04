using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Carbolibrary
{

	public class Sha512Encoder
	{

		static public string Encode(string text)
		{
			return string.Join("", SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(text)).Select(x => x.ToString("X2")));
		}

	}

}
