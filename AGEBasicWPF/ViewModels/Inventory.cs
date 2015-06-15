using AnyGameEngine.Modules.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AGEBasicWPF.ViewModels {
	public class Inventory {
		public ObservableCollection <ItemStackViewModel> List { get; set; }

		private ObservableCollection <ItemStack> source;

		public Inventory (ObservableCollection <ItemStack> source) {
			this.source = source;
			source.CollectionChanged += (a, b) => {
				if (b.NewItems != null) {
					foreach (var awd in b.NewItems) {
						Debug.WriteLine (awd);
					}
				}
				Debug.WriteLine ("A");
				if (b.OldItems != null) {
					foreach (var awd in b.OldItems) {
						Debug.WriteLine (awd);
					}
				}
			};
		}
	}
}
