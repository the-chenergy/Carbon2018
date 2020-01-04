using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carboutil
{

	static public class Extensions
	{

		static public int ToInt(this bool input)
		{
			return input ? 1 : 0;
		}

		static public bool ToBool(this int input)
		{
			return input == 1;
		}

		static public int Round(this double input)
		{
			return (int)(input + 0.5);
		}

		static public int Round(this float input)
		{
			return (int)(input + 0.5);
		}

		static public int RoundTo(this int input, int multipleOf)
		{
			return (int)(input / (double)multipleOf + 0.5) * multipleOf;
		}

		static public double RoundTo(this double input, double multipleOf)
		{
			return (int)(input / multipleOf + 0.5) * multipleOf;
		}

		static public double RoundTo(this float input, double multipleOf)
		{
			return (int)(input / multipleOf + 0.5) * multipleOf;
		}

		static public bool IsBetween(this int input, int x, int y)
		{
			return input >= Math.Min(x, y) && input <= Math.Max(x, y);
		}

		static public bool IsBetween(this double input, double x, double y)
		{
			return input >= Math.Min(x, y) && input <= Math.Max(x, y);
		}

		static public int SnapBetween(this int input, int x, int y)
		{
			return Math.Max(Math.Min(input, Math.Max(x, y)), Math.Min(x, y));
		}

		static public double SnapBetween(this double input, double x, double y)
		{
			return Math.Max(Math.Min(input, Math.Max(x, y)), Math.Min(x, y));
		}

		static public string Replace(this int input, int orig, string repl)
		{
			return input == orig ? repl : input.ToString();
		}

		static public string Replace(this double input, double orig, string repl)
		{
			return input == orig ? repl : input.ToString();
		}

		static public int Replace(this int input, int orig, int repl)
		{
			return input == orig ? repl : input;
		}

		static public double Replace(this double input, double orig, double repl)
		{
			return input == orig ? repl : input;
		}

		static public Color ToColor(this int input)
		{
			return Color.FromArgb(
				255,
				(byte)((input & 0xFF0000) >> 0x10),
				(byte)((input & 0x00FF00) >> 8),
				(byte)(input & 0x0000FF)
			);
		}

		static public Color ToArgbColor(this int input)
		{
			return Color.FromArgb(
				(byte)((input & 0xFF000000) >> 0x18),
				(byte)((input & 0x00FF0000) >> 0x10),
				(byte)((input & 0x0000FF00) >> 8),
				(byte)(input & 0x000000FF)
			);
		}

		static public string Only(this string input, bool cond)
		{
			return cond ? input : "";
		}

		static public string ToPlural(this string input, int count, string plural = "-s")
		{
			return $"{count} {(count == 1 ? input : plural.Replace("-", input))}";
		}

		static public double DistanceTo(this Point input, double x, double y)
		{
			return Math.Sqrt(Math.Pow(x - input.X, 2) + Math.Pow(y - input.Y, 2));
		}

		static public List<string> ToWordList(this string input)
		{
			return new Regex(@"[\t\r\n]").Replace(new Regex("[,.!?\\(\\);:\"]").Replace(input, ""), " ").ToLower().Split(' ').ToList();
		}

		static public double DistanceTo(this Point input, Point p)
		{
			return Math.Sqrt(Math.Pow(p.X - input.X, 2) + Math.Pow(p.Y - input.Y, 2));
		}

		static public int IndexOf<T>(this List<T> input, params T[] args)
		{
			for (int i = 0; ; i++)
			{
				i = input.IndexOf(args[0], i);

				if (i == -1 || i > input.Count - args.Length)
					break;

				if (input.GetRange(i, args.Length).SequenceEqual(args))
					return i;
			}

			return -1;
		}

		static public bool IsMouseEntered(this Control input)
		{
			return input.ClientRectangle.Contains(input.PointToClient(Control.MousePosition));
		}

		static public Control AddControl(this Control input, Control control, bool forceOnTop = true, bool forceHidden = false)
		{
			input.Controls.Add(control);

			if (forceHidden)
				control.Visible = false;

			if (forceOnTop)
				control.BringToFront();

			return control;
		}

	}

}
