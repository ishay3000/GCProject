using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GCProject.Miscellanies
{
	public abstract class BaseUserControl : UserControl
	{
		public string WindowTitle { get; set; }
		protected string title;
	}
}
