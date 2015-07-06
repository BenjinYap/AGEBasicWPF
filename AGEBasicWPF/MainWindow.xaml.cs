using AGEBasicWPF.ModuleHandlers;
using AGEBasicWPF.ViewModels;
using AGEBasicWPF.Views;
using AnyGameEngine;
using AnyGameEngine.GameData;
using AnyGameEngine.Modules.Core;
using AnyGameEngine.Other;
using AnyGameEngine.SaveData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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

namespace AGEBasicWPF {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow:Window {
		public Game Game { get; set; }
		public Save Save { get; set; }
		
		public GlobalResourcesList GlobalResourcesList { get; set; }
		public Inventory Inventory { get; set; }

		public ObservableCollection <LogicResult> LogicResults { get; set; }

		public Overlord Overlord { get; set; }

		private List <ModuleHandler> moduleHandlers = new List <ModuleHandler> ();

		private bool clickToContinue = false;

		public MainWindow () {
			this.Overlord = new Overlord ();
			this.Game = new Game (this.Overlord, "demo.txt");
			this.Save = Game.GetFreshSave ();

			this.GlobalResourcesList = new GlobalResourcesList (this.Game, this.Save);
			this.Inventory = new Inventory (this.Game, this.Save.ItemStacks);

			this.LogicResults = new ObservableCollection <LogicResult> ();
			//this.LogicResults.CollectionChanged += (a, b) => Debug.WriteLine (b.NewItems[0]);

			InitializeComponent ();

			if (this.clickToContinue == false) {
				this.continueLabel.Visibility = System.Windows.Visibility.Hidden;
			}

			moduleHandlers.Add (new CoreHandler (this, this.Overlord, this.Game, this.Save));
			moduleHandlers.Add (new GlobalResourcesHandler (this, this.Overlord, this.Game, this.Save));
			moduleHandlers.Add (new ItemsModuleHandler (this, this.Overlord, this.Game, this.Save));

			moduleHandlers.ForEach (a => {
				a.LogicResult += LogicResulted;
			});

			this.Overlord.Step (this.Game, this.Save);
		}

		public void DoClickToContinue () {
			if (this.clickToContinue) {
				this.continueLabel.Visibility = System.Windows.Visibility.Visible;
			} else {
				this.Overlord.Step (this.Game, this.Save);
			}
		}

		private void LogicResulted (object sender, LogicResultEventArgs e) {
			this.LogicResults.Add (e.Result);
		}

		private void Label_MouseDown (object sender, MouseButtonEventArgs e) {
			this.continueLabel.Visibility = System.Windows.Visibility.Hidden;
			this.Overlord.Step (this.Game, this.Save);
		}
	}
}
