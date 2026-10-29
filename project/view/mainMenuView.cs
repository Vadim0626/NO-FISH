using Model;
using System.Collections;
namespace Project.View;

class MainMenuView {

	private List<menuModel> options = new(); 
	private List<SettingsModel> settings = new();

	public MainMenuView() {
		options.Add(new menuModel("Start", true));
		options.Add(new menuModel("Options"));
		options.Add(new menuModel("Quit"));
		settings.Add(new SettingsModel("Enable Devmode", true));
	}

	public void showMenu() {
		foreach (menuModel opt in options) {
			opt.printOption();
		}
			
	}

	// TODO: Add placeholder settings menu that will return back to main menu once the option has been selected.
	public void showSettings() {
		Console.WriteLine($"=== Settings Menu: === \n");
		settings[0].printOption();
	}

	public void updateSelected(int current) {
		options[current].Selected = !options[current].Selected;
	}

	// Check if the index is still in range of the List
	// i can either go into the negatives (i < 0) or beyond the length of the array (i > options.Count - 1)
	public Boolean validateIndex(int i) {
		if(i < 0 || i > getListLength()) {
			return false;
		}
		return true;
	}

	public int getListLength() {
		return options.Count - 1;
	}
}
