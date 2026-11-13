namespace Controller;
using Project.View;
using Model;

public class MainMenuController {
	enum gameStates {
		Menu,
		Settings
	}
	private MainMenuView _menuView { get; } = new MainMenuView();
	private int _menuIndex { get; set; } = 0;
	private int _settingsIndex { get; set; } = 0;
	private int _left { get; } = Console.CursorLeft;
	private int _top { get; } = Console.CursorTop; 
	private ConsoleKeyInfo _keyInfo { get; set; }
	private gameStates _gameState { get; set; } = gameStates.Menu;

	public void startMenu() {
		_gameState = gameStates.Menu;
		_menuView.showMenu(_menuView.Menu);
		do {
			_keyInfo = Console.ReadKey(true);
			if (_keyInfo.Key == ConsoleKey.DownArrow) {
				handleDownInput(_menuIndex);
			}
			if (_keyInfo.Key == ConsoleKey.UpArrow) {
				handleUpInput(_menuIndex);
			}
			Console.SetCursorPosition(_left, _top);
			_menuView.showMenu(_menuView.Menu);
		}
		while (_keyInfo.Key != ConsoleKey.Enter);
		switch(_menuIndex) {
			case 0:
				//Start the Game
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
		bool isIndexInBounds = _menuView.validateIndex(i, getList()); 
		if(i >= 1 && !isIndexInBounds) {
			i = 0;
		}
		else if (i <= 0 && !isIndexInBounds) {
			i = _menuView.getListLength(getList()); 
		}
		return i;
	}

	public void controlSettings() {
		int savedIndex = _menuIndex;
		_gameState = gameStates.Settings;
		_menuIndex = _settingsIndex;
		clearMenu();
		Console.SetCursorPosition(_left,_top);
		_menuView.showSettings();
		while(_keyInfo.Key != ConsoleKey.Z) {
			_keyInfo = Console.ReadKey(true);
			switch(_keyInfo.Key) {
				case ConsoleKey.Enter:
					_menuView.toggleSetting(_menuIndex);
					break;
				case ConsoleKey.DownArrow:
					handleDownInput(_menuIndex);
					break;
				case ConsoleKey.UpArrow:
					handleUpInput(_menuIndex);
					break;
			}
			Console.SetCursorPosition(_left,_top);
			_menuView.showSettings();
		} 
		clearMenu();
		// Rudimentary fix, to avoid _menuIndex being disjointed after leaving the settings menu, better solution would most likely be to track them with separate vars but this will do for now :D 
		_settingsIndex = _menuIndex;
		_menuIndex = savedIndex;
		startMenu();

	}

	public void toggleSelected(int ind) {
		_menuView.updateSelected(ind, getList());
	}

	public List<Selectable> getList() {
		if(_gameState == gameStates.Menu) {
			return _menuView.Menu;
		} 
		else {
			return _menuView.Settings;
		}
	}

	public void clearMenu() {
		Console.SetCursorPosition(_left, _top);
		for(int i = 0; i < 10; i++) {
			Console.Write(new string(' ', Console.WindowWidth));
		}
		Console.SetCursorPosition(_left, _top);
	}
}
