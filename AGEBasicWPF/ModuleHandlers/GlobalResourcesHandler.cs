using AGEBasicWPF.ViewModels;
using AnyGameEngine;
using AnyGameEngine.Modules.Core;
using AnyGameEngine.Modules.GlobalResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGEBasicWPF.ModuleHandlers {
	public class GlobalResourcesHandler:ModuleHandler {

		public GlobalResourcesHandler (Overlord overlord):base (overlord) {
			overlord.GlobalResourcesModule.GlobalResourceSet += GlobalResourceSet;
			overlord.GlobalResourcesModule.GlobalResourceModified += GlobalResourceModified;
		}

		private void GlobalResourceSet (object sender, LogicGlobalResourceChangeEventArgs e) {
			this.FireLogicResultEvent (new LogicTextResult (string.Format ("{0} set to {1}", e.ResourceName, e.Amount)));
			this.Overlord.Step ();
		}

		private void GlobalResourceModified (object sender, LogicGlobalResourceChangeEventArgs e) {
			this.FireLogicResultEvent (new LogicTextResult (string.Format ("{0} changed by {1}", e.ResourceName, e.Amount)));
			this.Overlord.Step ();
		}
	}
}
