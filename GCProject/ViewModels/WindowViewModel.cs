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
		private ICommand _maximizeCommand;
		private ICommand _closeCommand;

		private ICommand _animOpenCommand;
		private ICommand _animCloseCommand;

		private Visibility _openMenuVisibility;
		private Visibility _closeMenuVisibility;

		private WindowState _windowState;

		private string _windowTitle;



		#region Props

		public string WindowTitle
		{
			get => _windowTitle;
			set { OnPropertyChanged("MinimizeCommand"); }
		}

	public ICommand MinimizeCommand
		{
			get => _minimizeCommand;
			set
			{
				_minimizeCommand = value;
				OnPropertyChanged("MinimizeCommand");
			}
		}

		public ICommand MaximizeCommand
		{
			get => _maximizeCommand;
			set => _maximizeCommand = value;
		}

		public ICommand CloseCommand
		{
			get => _closeCommand;
			set => _closeCommand = value;
		}

		public WindowState WindowState
		{
			get => _windowState;
			set
			{
				_windowState = value;
				OnPropertyChanged("WindowState");
			}
		}

		public ICommand AnimOpenCommand
		{
			get => _animOpenCommand;
			set =>_animOpenCommand = value;
		}

		public ICommand AnimCloseCommand
		{
			get => _animCloseCommand;
			set => _animCloseCommand = value;
		}

		public Visibility OpenMenuVisibility
		{
			get => _openMenuVisibility;
			set
			{
				_openMenuVisibility = value;
				OnPropertyChanged("OpenMenuVisibility");
			}
		}

		public Visibility CloseMenuVisibility
		{
			get => _closeMenuVisibility;
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
			_minimizeCommand = new RelayCommand((o => true), OnMinimize);
			_maximizeCommand = new RelayCommand((o => true), OnMaximize);
			_closeCommand = new RelayCommand((o => true), OnClose);
			_animOpenCommand = new RelayCommand(o => true, OnOpenAnim);
			_animCloseCommand = new RelayCommand(o => true, OnCloseAnim);
		}
	}
}
