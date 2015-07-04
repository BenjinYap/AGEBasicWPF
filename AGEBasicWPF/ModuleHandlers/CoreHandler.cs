using AGEBasicWPF.ViewModels;
using AnyGameEngine;
using AnyGameEngine.GameData;
using AnyGameEngine.Modules.Core;
using AnyGameEngine.SaveData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGEBasicWPF.ModuleHandlers {
	public class CoreHandler:ModuleHandler {

		public CoreHandler (MainWindow mainWindow, Overlord overlord, Game game, Save save):base (mainWindow, overlord, game, save) {
			overlord.CoreModule.RoomChanged += RoomChanged;
			overlord.CoreModule.OptionListed += OptionListed;
			overlord.CoreModule.Texted += Texted;
		}

		private void RoomChanged (object sender, LogicRoomChangeEventArgs e) {
			this.FireLogicResultEvent (new LogicTextResult ("Switched to room " + e.Name));
			this.MainWindow.DoClickToContinue ();
		}

		private void OptionListed (object sender, LogicOptionListEventArgs e) {
			this.MainWindow.continueLabel.Visibility = System.Windows.Visibility.Hidden;
			this.FireLogicResultEvent (new LogicOptionListResult (e.Text, e.Options));
		}

		private void Texted (object sender, LogicTextEventArgs e) {
			this.FireLogicResultEvent (new LogicTextResult (e.Text));
			this.MainWindow.DoClickToContinue ();
		}
	}
}
