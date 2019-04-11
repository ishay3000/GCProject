using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GCProject.Miscellanies;
using GCProject.ViewModels;

namespace GCProject.miscellanies
{
    static class FrameManager
    {
	    public static Frame MainFrame { get; set; }
		// TODO either find a use for this or remove it you lazy baboon
	    private static readonly Dictionary<string, UserControl> ExtrasDictionary;

	    static FrameManager()
	    {
		    ExtrasDictionary = new Dictionary<string, UserControl>();
	    }

		/// <summary>
		/// Moves the frame to a different page
		/// </summary>
		/// <param name="page">the user control page</param>
		public static void MovePage(UserControl page)
		{
			MainFrame.Content = page;
		}

	    public static void PutExtra(string key, UserControl value)
	    {
		    ExtrasDictionary[key] = value;
	    }

	    public static object GetExtra(string key)
	    {
		    if (ExtrasDictionary.ContainsKey(key))
		    {
			    return ExtrasDictionary[key];
		    }
		    else
		    {
			    return null;
		    }
	    }
    }
}
