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

		public CoreHandler (Overlord overlord, Game game, Save save):base (overlord, game, save) {
			overlord.CoreModule.RoomChanged += RoomChanged;
			overlord.CoreModule.OptionListed += OptionListed;
			overlord.CoreModule.Texted += Texted;
		}

		private void RoomChanged (object sender, LogicRoomChangeEventArgs e) {
			this.FireLogicResultEvent (new LogicTextResult ("Switched to room " + e.Name));
			this.Overlord.Step (this.Game, this.Save);
		}

		private void OptionListed (object sender, LogicOptionListEventArgs e) {
			this.FireLogicResultEvent (new LogicOptionListResult (e.Text, e.Options));
		}

		private void Texted (object sender, LogicTextEventArgs e) {
			this.FireLogicResultEvent (new LogicTextResult (e.Text));
			this.Overlord.Step (this.Game, this.Save);
		}
	}
}
