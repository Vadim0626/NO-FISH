using Model;
using System.Collections;
namespace Project.View;

class MainMenuView {

	public void showMenu(List<menuModel> option) {
		Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
		foreach (menuModel opt in option) {
			opt.printOption();
		}
			
	}

	public List<menuModel> initialiseModels() {
		List<menuModel> options = new List<menuModel>();   
		options.Add(new menuModel("Start"));
		options.Add(new menuModel("Options"));
		options.Add(new menuModel("Quit"));
		return options;
	}


	public void showSettings() {
	}

}
