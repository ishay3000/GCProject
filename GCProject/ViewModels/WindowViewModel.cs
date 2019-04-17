using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GCProject.Commands;

namespace GCProject.ViewModels
{
	class WindowViewModel : BaseViewModel
	{
		private ICommand _minimizeCommand;

        private Visibility _openMenuVisibility;
		private Visibility _closeMenuVisibility;

		private WindowState _windowState;

		private string _windowTitle;



		#region Props

		public string WindowTitle
        {
            get { return _windowTitle; }
            set
			{
				_windowTitle = value;
				OnPropertyChanged("WindowTitle");
			}
        }

        public ICommand MinimizeCommand
    {
        get { return _minimizeCommand; }
        set
			{
				_minimizeCommand = value;
				OnPropertyChanged("MinimizeCommand");
			}
    }

        public ICommand MaximizeCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public WindowState WindowState
        {
            get { return _windowState; }
            set
			{
				_windowState = value;
				OnPropertyChanged("WindowState");
			}
        }

        public ICommand AnimOpenCommand { get; set; }

        public ICommand AnimCloseCommand { get; set; }

        public Visibility OpenMenuVisibility
        {
            get { return _openMenuVisibility; }
            set
			{
				_openMenuVisibility = value;
				OnPropertyChanged("OpenMenuVisibility");
			}
        }

        public Visibility CloseMenuVisibility
        {
            get { return _closeMenuVisibility; }
            set
			{
				_closeMenuVisibility = value;
				OnPropertyChanged("CloseMenuVisibility");
			}
        }

        #endregion

		#region Window State Events

		public void OnClose(object obj)
		{
			Application.Current.Shutdown(0);
		}

		public void OnMinimize(object obj)
		{
			WindowState = WindowState.Minimized;
		}

		public void OnMaximize(object obj)
		{
			if (WindowState == WindowState.Maximized)
			{
				WindowState = WindowState.Normal;
			}
			else
			{
				WindowState = WindowState.Maximized;
			}
		}

		public void OnOpenAnim(object obj)
		{
			OpenMenuVisibility = Visibility.Collapsed;
			CloseMenuVisibility = Visibility.Visible;
		}

		public void OnCloseAnim(object obj)
		{
			OpenMenuVisibility = Visibility.Visible;
			CloseMenuVisibility = Visibility.Collapsed;
		}

		#endregion

		private static readonly WindowViewModel Instance = new WindowViewModel();

		public static WindowViewModel INSTANCE => Instance;

		private WindowViewModel()
		{
			_minimizeCommand = new RelayCommand(() =>
            {
                OnMinimize(null);
            });
            MaximizeCommand = new RelayCommand(() =>
            {
                OnMaximize(null);
            });
            CloseCommand = new RelayCommand(() =>
            {
                OnClose(null);
            });
            AnimOpenCommand = new RelayCommand(() =>
            {
                OnOpenAnim(null);
            });
            AnimCloseCommand = new RelayCommand(() =>
            {
                OnCloseAnim(null);
            });
        }
	}
}
