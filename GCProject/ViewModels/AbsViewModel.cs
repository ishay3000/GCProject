using System.ComponentModel;
using System.Runtime.CompilerServices;
using GCProject.Annotations;

namespace GCProject.ViewModels
{
	public abstract class AbsViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		
		public virtual void OnPropertyChanged(string propertyName = null)
		{
			var handler = PropertyChanged;
			// not using null propagation (handler?.invoke) because VS 2012 does not support it
			if (handler != null)
			{
				handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}