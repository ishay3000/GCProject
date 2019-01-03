﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GCProject.ViewModels;

namespace GCProject.Views
{
	/// <summary>
	/// Interaction logic for CardControl.xaml
	/// </summary>
	public partial class CardControl : UserControl
	{
		readonly MenuCardViewModel _viewModel = new MenuCardViewModel();
		public CardControl()
		{
			InitializeComponent();
			DataContext = _viewModel;
		}

		//public static readonly DependencyProperty ButtonCommandProperty = DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(CardControl), new PropertyMetadata(default(ICommand)));

		//public ICommand ButtonCommand
		//{
		//	get
		//	{
		//		return (ICommand)GetValue(ButtonCommandProperty);
		//	}
		//	set
		//	{
		//		SetValue(ButtonCommandProperty, value);
		//	}
		//}
		//private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		//{
		//	_viewModel.CardCommand.Execute(null);
		//}
	}
}
