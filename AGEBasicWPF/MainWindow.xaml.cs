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

		public ObservableCollection <LogicResult> LogicResults { get; set; }

		private Overlord overlord;

		private List <ModuleHandler> moduleHandlers = new List <ModuleHandler> ();

		public MainWindow () {
			this.overlord = new Overlord ();
			this.Game = GameStorage.FromXml (File.ReadAllText ("game.txt"));
			this.Save = Game.GetFreshSave ();
			this.GlobalResourcesList = new GlobalResourcesList (this.Game, this.Save);

			this.LogicResults = new ObservableCollection <LogicResult> ();

			InitializeComponent ();

			this.overlord.SetGameAndSave (this.Game, this.Save);

			moduleHandlers.Add (new CoreHandler (overlord));
		}

		
	}
}
