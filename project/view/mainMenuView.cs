using Model;
using System.Collections;
using System.Collections.Generic;
namespace Project.View;

class MainMenuView {

	private List<Selectable> _menu = new List<menuModel>(); 
	public List<menuModel> Menu {
		get { return _menu; }
		set { _menu = value; }
	}
	private List<Selectable> _settings = new List<SettingsModel>();
	public List<SettingsModel> Settings {
		get { return _settings; }
		set { _settings = value; }
	}

	public MainMenuView() {
		Menu.Add(new menuModel("Start", true)); 
		Menu.Add(new menuModel("Options"));
		Menu.Add(new menuModel("Quit"));
		Settings.Add(new SettingsModel("Enable Devmode", true));
		Settings.Add(new SettingsModel("Test Setting 1"));
		Settings.Add(new SettingsModel("Test Setting 2"));
	}

	public void showMenu(IEnumerable<Selectable> options) {
		foreach (Selectable opt in options) {
			opt.printOption();
		}
	}

	public void showSettings() {
		Console.WriteLine($"=== Settings Menu: === \n");
		showMenu(Settings);
		Console.WriteLine($"\n=== Press Z to return to the Menu ===");
	}

	public void updateSelected(int current, List<Selectable> selectedMenu) {
		selectedMenu[current].Selected = !selectedMenu[current].Selected;
	}

	public void toggleSetting(int current) {
		Settings[current].Toggled = !Settings[current].Toggled;
	}

	// Check if the index is still in range of the List
	// i can either go into the negatives (i < 0) or beyond the length of the array (i > menu.Count - 1)
	public bool validateIndex(int i, List<Selectable> selectedMenu) {
		if(i < 0 || i > getListLength(selectedMenu)) {
			return false;
		}
		return true;
	}

	public int getListLength(List<Selectable> selectedMenu) {
		return selectedMenu.Count - 1;
	}
}
