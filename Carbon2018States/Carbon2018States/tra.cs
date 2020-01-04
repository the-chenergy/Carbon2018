using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace System
{

	/// <summary>
	/// This is not a class. This is a method (Whaaaaat??).
	/// </summary>
	public class tra
	{

		/// <summary>
		/// An advanced or maybe the world-best trace method.
		/// It simply writes everything you pass as args into the output-panel.
		/// (You can input string "NODETAILS!!" as the first argument if you don't wanna see the details of objects.)
		/// </summary>
		static public string ce(params object[] args)
		{
			bool showDetails = (args.Length == 0 || args[0] == null || args[0].ToString() != "NODETAILS!!");

			string output = "";

			for (int i = 0, l = args.Length; i < l; i++)
			{
				if (!showDetails && i == 0)
					continue;

				object p = args[i];

				output += ToString(p, showDetails);

				if (i < l - 1)
					output += "; ";
			}

			Trace.WriteLine(output);

			return output;
		}

		/// <summary>
		/// Returns the string form of any object.
		/// </summary>
		static protected string ToString(object x, bool showDetails = false)
		{
			if (x == null)
				return "null";

			if (x is string)
				return $"\"{(string)x}\"";

			if (x is bool)
				return x.ToString().ToLower();

			if (x is char)
			{
				if ((char)x == 0)
					return "''";

				return $"'{x.ToString()}'";
			}

            double n;

			// if (x is number)
			if (double.TryParse(x.ToString(), out n))
				return n.ToString();

			// for anything that already has a customized ToString method
			// such as a Point instance: {X=2323, Y=2323}
			if (x.ToString()[0] == '{')
				return x.ToString();

			if (x is Array)
				return ArrayToString((Array)x);

			if (x is IList)
			{
				object[] a = new object[((IList)x).Count];

				((IList)x).CopyTo(a, 0);

				return ArrayToString(a);
			}

			if (x is IDictionary)
				return DictToString((IDictionary)x);

			return ObjectToString(x, showDetails);
		}

		/// <summary>
		/// Returns the string form of an array.
		/// </summary>
		static protected string ArrayToString(Array a)
		{
			string output = "[";

			for (int i = 0, l = a.Length; i < l; i++)
			{
				output += ToString(a.GetValue(i));

				if (i < l - 1)
					output += ", ";
			}

			return output + "]";
		}

		/// <summary>
		/// Returns the string form of a dictionary.
		/// </summary>
		static protected string DictToString(IDictionary d)
		{
			string output = "{";

			foreach (dynamic p in d)
			{
				output += $"{ToString(p.Key, false)}: {ToString(p.Value, false)}, ";
			}

			if (output.Length > 2)
				output = output.Substring(0, output.Length - 2);

			return output + "}";
		}

		/// <summary>
		/// Returns the string form of anything else.
		/// </summary>
		static protected string ObjectToString(object x, bool showDetails)
		{
			Type type = x.GetType();

			string output = type.ToString();

			if (!showDetails)
				return $"(object {output.Substring(output.LastIndexOf(".") + 1)})";

			// (Type){Prop0="Val0", Prop1="Val1"}
			output = $"(object {output.Substring(output.LastIndexOf(".") + 1)}) {{";

			List<PropertyInfo> props = type.GetProperties().OrderBy(y => y.Name).ToList();

			foreach (PropertyInfo p in props)
			{
				try
				{
					object propVal = p.GetValue(x, null);

					output += $"\n\t{p.Name} = {ToString(propVal)},";
				}
				// index-ed properties such as a char of a string is represented as "str[i]"
				catch (Exception)
				{
				}
			}

			// the comma at the end
			output = output.Substring(0, output.Length - 1); 

			return output + "\n}";
		}

	}

}
