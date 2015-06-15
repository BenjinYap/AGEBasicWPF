using AGEBasicWPF.ViewModels;
using AnyGameEngine.Modules.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	/// Interaction logic for Inventory.xaml
	/// </summary>
	public partial class InventoryView:UserControl {
		public ObservableCollection <ItemStack> Source {
			get { return (ObservableCollection <ItemStack>) this.GetValue (SourceProperty); }
			set { this.SetValue (SourceProperty, value); }
		}
		
		public ObservableCollection <ItemStackViewModel> ItemStacks { get; set; }

		public InventoryView () {
			this.ItemStacks = new ObservableCollection <ItemStackViewModel> ();

			InitializeComponent ();
		}

		

		public static readonly DependencyProperty SourceProperty = DependencyProperty.Register ("Source", typeof (ObservableCollection <ItemStack>), typeof (InventoryView), new PropertyMetadata (null));
	}
}
