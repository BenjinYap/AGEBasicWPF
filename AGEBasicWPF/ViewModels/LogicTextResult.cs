using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGEBasicWPF.ViewModels {
	public class LogicTextResult:LogicResult {
		public string Text { get; set; }

		public LogicTextResult (string text) {
			this.Text = text;
		}
	}
}
