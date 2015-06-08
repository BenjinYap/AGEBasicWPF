using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AGEBasicWPF.Views {
	/// <summary>
	/// Interaction logic for LogicOptionListBox.xaml
	/// </summary>
	public partial class LogicOptionListBox:LogicBox {
		public LogicOptionListBox () {
			InitializeComponent ();
		}

		private void ListBox_PreviewMouseDown (object sender, MouseButtonEventArgs e) {
			ItemsControl listBox = sender as ItemsControl;
			ListBoxItem item = ItemsControl.ContainerFromElement (listBox, e.OriginalSource as DependencyObject) as ListBoxItem;
			listBox.PreviewMouseDown -= ListBox_PreviewMouseDown;
			

			Debug.WriteLine (listBox.ItemContainerGenerator.IndexFromContainer (item));
		}
	}
}
