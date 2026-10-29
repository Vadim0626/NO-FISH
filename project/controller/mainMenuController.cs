namespace Controller;
using Project.View;

public class MainMenuController {

	private MainMenuView _menuView { get; } = new MainMenuView();
	private int _menuIndex { get; set; } = 0;
	private int _left { get; } = Console.CursorLeft;
	private int _top { get; } = Console.CursorTop; 
	private ConsoleKeyInfo keyInfo { get; set; }

	
	public void startMenu() {
		_menuView.showMenu();
		ConsoleKeyInfo keyInfo;

		do {
			keyInfo = Console.ReadKey(false);
			if (keyInfo.Key == ConsoleKey.DownArrow) {
				handleDownInput(_menuIndex);
			}
			if (keyInfo.Key == ConsoleKey.UpArrow) {
				handleUpInput(_menuIndex);
			}
			Console.SetCursorPosition(_left, _top);
			_menuView.showMenu();
		}
		while (keyInfo.Key != ConsoleKey.Enter);

		switch(_menuIndex) {
			case 0:
				//Start game
				break;
			case 1: 
				//Show Settings
				controlSettings();	
				break;
			case 2: 
				//End the Application
				break;
		}
	}
	// set Selected of current index to false, so upcoming index can be set to true
	public void handleDownInput(int i) {
		toggleSelected(i);
		i++;
		i = checkIndex(i);
		toggleSelected(i);
		_menuIndex = i;
	}

	public void handleUpInput(int i) {
		toggleSelected(i);
		i--;
		i = checkIndex(i);
		toggleSelected(i);
		_menuIndex = i;
	}
	
	public int checkIndex(int i) {
		bool isIndexInBounds = _menuView.validateIndex(i); 
		if(i >= 1 && !isIndexInBounds) {
			i = 0;
		}
		else if (i <= 0 && !isIndexInBounds) {
			i = _menuView.getListLength(); 
		}
		return i;
	}

	public void controlSettings() {
		bool returnSelected = false;
		_menuIndex = 0;
		Console.SetCursorPosition(_left, _top);
		for(int i = 0; i <= _menuView.getListLength(); i++) {
			Console.WriteLine($"\r                        ");
		}
		Console.SetCursorPosition(_left,_top);
		_menuView.showSettings();
		while(!returnSelected) {
			keyInfo = Console.ReadKey(false);
			Console.SetCursorPosition(_left, _top);
			_menuView.showSettings();
			if(keyInfo.Key == ConsoleKey.Enter) {
				Console.WriteLine("Enter has been selected");
				break;
			}
		}
	}

	public void toggleSelected(int ind) {
		_menuView.updateSelected(ind);
	}

}
