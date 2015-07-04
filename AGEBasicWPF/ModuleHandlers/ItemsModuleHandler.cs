using AGEBasicWPF.ViewModels;
using AnyGameEngine;
using AnyGameEngine.GameData;
using AnyGameEngine.Modules.Items;
using AnyGameEngine.SaveData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGEBasicWPF.ModuleHandlers {
	public class ItemsModuleHandler:ModuleHandler {

		public ItemsModuleHandler (MainWindow mainWindow, Overlord overlord, Game game, Save save):base (mainWindow, overlord, game, save) {
			overlord.ItemsModule.ItemModify += ItemModified;
		}

		private void ItemModified (object sender, LogicItemModifyEventArgs e) {
			this.FireLogicResultEvent (new LogicTextResult (string.Format ("{0} changed by {1}", e.ItemName, e.Quantity)));
			this.MainWindow.DoClickToContinue ();
		}
	}
}
