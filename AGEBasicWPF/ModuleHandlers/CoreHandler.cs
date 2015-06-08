using AGEBasicWPF.ViewModels;
using AnyGameEngine;
using AnyGameEngine.Modules.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGEBasicWPF.ModuleHandlers {
	public class CoreHandler:ModuleHandler {

		public CoreHandler (Overlord overlord):base (overlord) {
			overlord.CoreModule.OptionListed += OptionListed;
			overlord.CoreModule.Texted += Texted;
		}

		private void OptionListed (object sender, LogicOptionListEventArgs e) {
			this.FireLogicResultEvent (new LogicOptionListResult (e.Text, e.Options));
		}

		private void Texted (object sender, LogicTextEventArgs e) {
			this.FireLogicResultEvent (new LogicTextResult (e.Text));
			this.Overlord.Step ();
		}
	}
}
