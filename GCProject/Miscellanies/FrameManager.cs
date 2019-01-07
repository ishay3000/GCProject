using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GCProject.miscellanies
{
    static class FrameManager
    {
	    public static Frame MainFrame { get; set; }
	    private static Dictionary<string, object> _extrasDictionary = new Dictionary<string, object>();

	    public static void MovePage(object page)
	    {
		    MainFrame.Content = page;
	    }

	    public static void PutExtra(string key, object value)
	    {
		    _extrasDictionary[key] = value;
	    }

	    public static object GetExtra(string key)
	    {
		    if (_extrasDictionary.ContainsKey(key))
		    {
			    return _extrasDictionary[key];
		    }
		    else
		    {
			    return null;
		    }
	    }
    }
}
