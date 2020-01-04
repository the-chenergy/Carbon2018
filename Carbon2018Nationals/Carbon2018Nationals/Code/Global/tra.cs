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

		#region ENUM SETTINGS

		/// <summary>
		/// tra.ce Settings
		/// </summary>
		[Flags]
		public enum ceSettings
		{

			ForceHideDetails = 1,
			ForceShowDetails = 2,
			FormatStrings = 4,
			TraceStack = 8,
			TraceUnformattedStack = 16,

		}

		#endregion

		/// <summary>
		/// An advanced or maybe the world's best trace method.
		/// It simply writes everything you pass as args into the output-panel.
		/// </summary>
		static public string ce(params object[] args)
		{
			ceSettings settings = default;

			if (args.Length > 0 && args[0] is ceSettings)
				settings = (ceSettings)args[0];

			string output = "";

			if (settings.HasFlag(ceSettings.TraceStack))
				output += FormatStackTrace(new StackTrace().ToString());
			else if (settings.HasFlag(ceSettings.TraceUnformattedStack))
				output += new StackTrace().ToString();

			for (int i = (settings == default ? 0 : 1), l = args.Length; i < l; i++)
			{
				output += ToString(
					args[i],
					!settings.HasFlag(ceSettings.ForceHideDetails),
					settings.HasFlag(ceSettings.ForceShowDetails),
					settings.HasFlag(ceSettings.FormatStrings)
				);

				if (i < l - 1)
					output += "; ";
			}

			Trace.WriteLine(output);

			return output;
		}

		/// <summary>
		/// Returns the string form of any object.
		/// </summary>
		static protected string ToString(object x, bool showDetails, bool forceShowDetails = false, bool formatStrings = false, bool formatStringsWithQuotes = true)
		{
			if (x == null)
				return "null";

			if (x is Enum)
				return $"{x.GetType().Name}.{x.ToString()}";

			if (x is string output)
			{
				if (formatStrings)
					output = output.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", @"\r").Replace("\n", @"\n").Replace("\b", @"\b").Replace("\t", @"\t");

				if (formatStringsWithQuotes)
					return $"\"{output}\"";

				return output;
			}

			if (x is bool)
				return x.ToString().ToLower();

			if (x is char)
			{
				if ((char)x == 0)
					return @"'\0'";

				return $"'{ToString(x.ToString(), false, false, true, false)}'";
			}

			// if (x is interger)
			if (long.TryParse(x.ToString(), out long i))
				return i.ToString();

			// if (x is number)
			if (double.TryParse(x.ToString(), out double n))
				return n.ToString();

			// for anything that already has a customized ToString method
			// such as a Point instance: {X=2323, Y=2323}
			if (x.ToString()[0] == '{')
				return x.ToString();

			if (x is Array)
				return ArrayToString((x as Array), forceShowDetails);

			if (x is IDictionary)
				return DictToString((IDictionary)x, forceShowDetails);

			if (x is IEnumerable list)
				return ArrayToString(list.Cast<dynamic>().ToArray(), forceShowDetails, list.GetType().GetGenericArguments()[0].Name.Replace("[]", ""));

			if (x.GetType().Name.Contains("Action")) // x is a method
			{
				MethodInfo info = (x as dynamic).Method;
				string returnTypeName = info.ReturnType.Name == "Void" ? "void" : info.ReturnType.Name;

				return $"{returnTypeName} {info.Name}({string.Join(", ", info.GetParameters().Select(y => $"{y.ParameterType.Name} {y.Name}"))}) {{}}";
			}

			return ObjectToString(x, showDetails);
		}

		/// <summary>
		/// Returns the string form of an array.
		/// </summary>
		static protected string ArrayToString(Array a, bool showDetails, string typeName = "")
		{
			if (!showDetails)
				return $"{typeName}[{a.Length}]";

			string output = "[";

			for (int i = 0, l = a.Length; i < l; i++)
			{
				output += ToString(a.GetValue(i), true);

				if (i < l - 1)
					output += ", ";
			}

			return output + "]";
		}

		/// <summary>
		/// Returns the string form of a dictionary.
		/// </summary>
		static protected string DictToString(IDictionary d, bool showDetails)
		{
			string output = "{";

			foreach (dynamic p in d)
			{
				output += $"\n\t{ToString(p.Key, showDetails)}: {ToString(p.Value, showDetails)},";
			}

			if (output.Length > 1)
				output = output.Substring(0, output.Length - 1);

			return output + "\n}";
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

			Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

			// get properties
			foreach (PropertyInfo p in type.GetProperties())
			{
				try
				{
					keyValuePairs[p.Name] = ToString(p.GetValue(x), false);
				}
				// index-ed properties such as a char of a string is represented as "str[i]"
				catch
				{
					continue;
				}
			}

			// get fields (variables, not getters/setters)
			foreach (FieldInfo p in type.GetFields())
			{
				try
				{
					keyValuePairs[p.Name] = ToString(p.GetValue(x), false);
				}
				catch
				{
					continue;
				}
			}

			List<string> keys = keyValuePairs.Keys.OrderBy(y => y).ToList();

			foreach (string p in keys)
				output += $"\n\t{p} = {keyValuePairs[p]},";

			// the comma at the end
			output = output.Substring(0, output.Length - 1);

			return output + "\n}";
		}

		static protected string FormatStackTrace(string stackTrace)
		{
			List<string> lines = stackTrace.Split('\n').ToList();

			lines.RemoveAt(0);

			return string.Join("\n", lines.Where(x => (
				!x.Contains(" System.")
			)).Select(x =>
				x.Replace("..ctor()", "()")
			));
		}

	}

}
