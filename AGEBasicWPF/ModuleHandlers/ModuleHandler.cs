using AGEBasicWPF.ViewModels;
using AnyGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGEBasicWPF.ModuleHandlers {
	public class ModuleHandler {
		public delegate void LogicResultEventHandler (object sender, LogicResultEventArgs e);
		public event LogicResultEventHandler LogicResult;

		protected Overlord Overlord;

		public ModuleHandler (Overlord overlord) {
			this.Overlord = overlord;
		}

		protected void FireLogicResultEvent (LogicResult result) {
			if (this.LogicResult != null) {
				this.LogicResult (this, new LogicResultEventArgs (result));
			}
		}
	}
}
