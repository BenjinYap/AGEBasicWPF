using AGEBasicWPF.ViewModels;
using AnyGameEngine;
using AnyGameEngine.GameData;
using AnyGameEngine.SaveData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGEBasicWPF.ModuleHandlers {
	public class ModuleHandler {
		public delegate void LogicResultEventHandler (object sender, LogicResultEventArgs e);
		public event LogicResultEventHandler LogicResult;

		protected MainWindow MainWindow;
		protected Overlord Overlord;
		protected Game Game;
		protected Save Save;

		public ModuleHandler (MainWindow mainWindow, Overlord overlord, Game game, Save save) {
			this.MainWindow = mainWindow;
			this.Overlord = overlord;
			this.Game = game;
			this.Save = save;
		}

		protected void FireLogicResultEvent (LogicResult result) {
			if (this.LogicResult != null) {
				this.LogicResult (this, new LogicResultEventArgs (result));
			}
		}
	}
}
