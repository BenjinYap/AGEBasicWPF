using AnyGameEngine.GameData;
using AnyGameEngine.Modules.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AGEBasicWPF.ViewModels {
	public class ItemStackViewModel {//:INotifyPropertyChanged {
		//public event PropertyChangedEventHandler PropertyChanged;

		public ItemStack Model { get; set; }

		public string ItemName { get; set; }
		
		//public int Quantity {
		//	get { return this.quantity; }
		//	set {
		//		if (this.quantity != value) {
		//			this.quantity = value;
		//			this.NotifyPropertyChanged ();
		//		}
		//	}
		//}

		//private int quantity; 

		public ItemStackViewModel (Game game, ItemStack model) {
			this.Model = model;
			//this.Model.PropertyChanged += (a, b) => this.Quantity = model.Quantity;

			this.ItemName = game.Items.Find (a => a.Id == model.ItemId).Name;
			//this.Quantity = model.Quantity;
		}

		//private void NotifyPropertyChanged ([CallerMemberName] string propertyName = null) {
		//	if (this.PropertyChanged != null) {
		//		this.PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		//	}
		//}
	}
}
