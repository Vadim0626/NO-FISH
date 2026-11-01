using Model;
namespace Project.View;

class MainMenuView {

	private List<menuModel> _menu = new(); 
	public List<menuModel> Menu {
		get { return _menu; }
		set { _menu = value; }
	}
	private List<SettingsModel> _settings = new();
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
		Settings[0].printOption();
	}

	public void updateSelected(int current) {
		Menu[current].Selected = !Menu[current].Selected;
	}

	// Check if the index is still in range of the List
	// i can either go into the negatives (i < 0) or beyond the length of the array (i > menu.Count - 1)
	public bool validateIndex(int i) {
		if(i < 0 || i > getListLength()) {
			return false;
		}
		return true;
	}

	public int getListLength() {
		return Menu.Count - 1;
	}
}
