using AnyGameEngine.GameData;
using AnyGameEngine.Other;
using AnyGameEngine.SaveData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AGEBasicWPF.ViewModels {
	public class GlobalResourcesList:INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableDictionary <string, GlobalResource> List { get; set; }

		private Game game;
		private Save save;

		public GlobalResourcesList (Game game, Save save) {
			this.game = game;
			this.save = save;

			this.save.GlobalResources.PropertyChanged += GlobalResourceChanged;

			this.List = new ObservableDictionary <string, GlobalResource> ();

			this.game.GlobalResources.ForEach (a => {
				this.List [a.Id] = new GlobalResourcesList.GlobalResource (a.Name, a.StartingAmount);
			});
		}

		private void GlobalResourceChanged (object sender, PropertyChangedEventArgs e) {
			this.List [e.PropertyName].Quantity = this.save.GlobalResources [e.PropertyName];
		}

		private void NotifyPropertyChanged ([CallerMemberName] string propertyName = null) {
			if (this.PropertyChanged != null) {
				this.PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
			}
		}

		public class GlobalResource:INotifyPropertyChanged {
			public event PropertyChangedEventHandler PropertyChanged;

			public string Name { get; set; }
			public float Quantity {
				get { return this.quantity; }
				set {
					if (this.quantity != value) {
						this.quantity = value;
						this.NotifyPropertyChanged ();
					}
				}
			}

			private float quantity;

			public GlobalResource (string name, float quantity) {
				this.Name = name;
				this.Quantity = quantity;
			}

			private void NotifyPropertyChanged ([CallerMemberName] string propertyName = null) {
				if (this.PropertyChanged != null) {
					this.PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
				}
			}
		}
	}
}
