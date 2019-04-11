using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCProject.ViewModels;

namespace GCProject.Models
{
	class ScanResultsModel
	{
		private int _number;

		public int Number
		{
			get => _number;
			set => _number = value;
		}

		public ScanResultsModel(int number)
		{
			_number = number;
		}
	}
}
