using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGEBasicWPF.ViewModels {
	public class LogicResultEventArgs:EventArgs {
		public LogicResult Result;

		public LogicResultEventArgs (LogicResult result) {
			this.Result = result;
		}
	}
}
