using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carboutil
{

	public class Carbotimeout
	{

		/// ########################## PUBLIC PROPERTIES ############################



		/// ######################### PRIVATE PROPERTIES ############################

		static protected Dictionary<Timer, Action> callbackDict = new Dictionary<Timer, Action>();
		static protected Dictionary<Action, Timer> timerDict = new Dictionary<Action, Timer>();
		static protected Dictionary<Timer, int> countDict = new Dictionary<Timer, int>();

		/// ########################### PUBLIC METHODS ##############################

		static public void Set(int timeout, Action callback, int count = 1)
		{
			Cancel(callback);

			Timer timer = timerDict[callback] = new Timer()
			{
				Interval = timeout,
			};

			callbackDict[timer] = callback;
			countDict[timer] = count;

			timer.Tick += OnTimerTick;

			timer.Start();
		}

		static public void Cancel(Action callback)
		{
			if (!timerDict.ContainsKey(callback) || timerDict[callback] == null)
				return;

			Clear(timerDict[callback]);
		}

		/// ########################### PRIVATE METHODS #############################

		static protected void Clear(Timer timer)
		{
			timer.Tick -= OnTimerTick;

			timer.Stop();
			timer.Dispose();

			timerDict[callbackDict[timer]] = null;
		}

		/// ############################### EVENTS ##################################

		static protected void OnTimerTick(object sender, EventArgs e)
		{
			Timer timer = sender as Timer;

			if (--countDict[timer] == 0)
				Clear(timer);
			
			callbackDict[timer]();
		}

	}

}