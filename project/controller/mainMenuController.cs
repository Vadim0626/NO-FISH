namespace Controller;
using Project.View;

//TODO: Figure out how to solve ref problem
public class MainMenuController {

	private MainMenuView _menuView { get; } = new MainMenuView();
	private int _menuIndex { get; set; } = 0;
	
	public void startMenu() {
		_menuView.showMenu();
		ConsoleKeyInfo keyInfo;

		do {
			keyInfo = Console.ReadKey(false);
			if (keyInfo.Key == ConsoleKey.DownArrow) {
				handleDownInput(ref _menuIndex);
			}
			if (keyInfo.Key == ConsoleKey.UpArrow) {
				handleUpInput(ref _menuIndex);
			}
			_menuView.showMenu();
			Console.WriteLine(_menuIndex);
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
	//This is what is meant by "ref problem", I cannot call a ref inside another method
	//Potentially will have to break up toggleSelected and make the validation inside the handleInput Methods
	public void handleDownInput(ref int i) {
		toggleSelected(ref i--, i);
	}

	public void handleUpInput(ref int i) {
		toggleSelected(ref i++, i);
	}

	public void toggleSelected(ref int next, int prev) {
		Boolean isIndexInBounds = _menuView.validateIndex(next); 
		if(next > 1 && !isIndexInBounds) {
			next = 0;
		}
		else if (next < 1 && !isIndexInBounds) {
			next = _menuView.getListLength(); 
		}
		
		_menuView.updateSelected(next, prev);
	}

}
