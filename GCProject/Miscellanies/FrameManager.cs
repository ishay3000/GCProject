using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GCProject.Miscellanies;
using GCProject.ViewModels;
using GCProject.Views;

namespace GCProject.miscellanies
{

	public enum ControlsTitles
	{
		Cards,
		Settings,
		ScanResults
	}
    static class FrameManager
    {
	    public static Frame MainFrame { get; set; }
		// TODO either find a use for this or remove it you lazy baboon
	    private static readonly Dictionary<ControlsTitles, 
		    Tuple<UserControl, string>> ControlsTitlesDict;

	    static FrameManager()
	    {
		    ControlsTitlesDict = new Dictionary<ControlsTitles, Tuple<UserControl, string>>();
			InitDictionary();
	    }

	    private static void InitDictionary()
	    {
		    ControlsTitlesDict[ControlsTitles.Cards] = 
			    new Tuple<UserControl, string>(new CustomCardControl(), "Welcome to Telephony Scanner");
		    ControlsTitlesDict[ControlsTitles.ScanResults] =
			    new Tuple<UserControl, string>(new ScanResultsControl(), "Scan Results");
		}

		/// <summary>
		/// Moves the frame to a different page
		/// </summary>
		/// <param name="pageTitle">the page title</param>
		public static void MovePage(ControlsTitles pageTitle)
	    {
		    if (ControlsTitlesDict.ContainsKey(pageTitle))
		    {
			    var controlTuple = ControlsTitlesDict[pageTitle];
				// change page
			    MainFrame.Content = controlTuple.Item1;
				// change title
			    WindowViewModel.INSTANCE.WindowTitle = controlTuple.Item2;
		    }
	    }

	    //public static void PutExtra(string key, UserControl value)
	    //{
	    // ExtrasDictionary[key] = value;
	    //}

	    //public static object GetExtra(string key)
	    //{
	    // if (ExtrasDictionary.ContainsKey(key))
	    // {
	    //  return ExtrasDictionary[key];
	    // }
	    // else
	    // {
	    //  return null;
	    // }
	    //}
    }
}
