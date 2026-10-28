namespace Controller;
using Project.View;

//TODO: Figure out how to solve ref problem
public class MainMenuController {

	private MainMenuView _menuView { get; } = new MainMenuView();
	private int _menuIndex { get; set; } = 0;
	
	public void startMenu() {
		int left = Console.CursorLeft;
		int top = Console.CursorTop;
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
			Console.SetCursorPosition(left, top);
			_menuView.showMenu();
		}
		while (keyInfo.Key != ConsoleKey.Enter);

		switch(_menuIndex) {
			case 0:
				//Start game
				break;
			case 1: 
				//Show Settings
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
		Boolean isIndexInBounds = _menuView.validateIndex(i); 
		if(i >= 1 && !isIndexInBounds) {
			i = 0;
		}
		else if (i <= 0 && !isIndexInBounds) {
			i = _menuView.getListLength(); 
		}
		return i;
	}

	public void toggleSelected(int ind) {
		_menuView.updateSelected(ind);
	}

}
