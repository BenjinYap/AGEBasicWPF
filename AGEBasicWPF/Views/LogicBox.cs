using AnyGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AGEBasicWPF.Views {
	public class LogicBox:ContentControl {
		
		public Overlord Overlord {
			get { return (Overlord) this.GetValue (OverlordProperty); }
			set { this.SetValue (OverlordProperty, value); }
		}

		public static readonly DependencyProperty OverlordProperty = DependencyProperty.Register ("Overlord", typeof (Overlord), typeof (LogicBox), new PropertyMetadata (null));
	}
}
