using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGEBasicWPF.ViewModels {
	public class LogicOptionListResult:LogicResult {
		public string Text { get; set; }
		public string [] Options { get; set; }

		public LogicOptionListResult (string text, string [] options) {
			this.Text = text;
			this.Options = options;
		}
	}
}
