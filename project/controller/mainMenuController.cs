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
			Console.WriteLine("index before any inputs " + _menuIndex);
			if (keyInfo.Key == ConsoleKey.DownArrow) {
				handleDownInput(_menuIndex);
			}
			if (keyInfo.Key == ConsoleKey.UpArrow) {
				handleUpInput(_menuIndex);
			}
			Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
			// _menuView.showMenu();

			Console.WriteLine("Index after input " + _menuIndex);
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
	// these Methods may be a little confusing so here's a brief explanation:
	// - The value of the index that would come after is being checked (e.g. i = 1, downInput would cause it to be 2, as such 2 will be the value that is being checked)
	// - Since we're already updating the index after checking it, we have to pass the opposite direction of the input as the "previous" parameter for toggleSelected()
	// - Questionable solution, definitely something to refactor in the future
	public void handleDownInput(int i) {
		i = checkIndex(i++);
		toggleSelected(i, i--);
		_menuIndex = i;
	}

	public void handleUpInput(int i) {
		i = checkIndex(i--);
		toggleSelected(i, i++);
		_menuIndex = i;
	}
	
	public int checkIndex(int i) {
		Boolean isIndexInBounds = _menuView.validateIndex(i); 
		if(i > 1 && !isIndexInBounds) {
			i = 0;
		}
		else if (i <= 0 && !isIndexInBounds) {
			i = _menuView.getListLength(); 
		}
		Console.WriteLine("debug output of i after checking " + i);
		return i;
	}

	// TODO: Rewrite toggleSelected to only take one int param.
	// - Doing it with multiple parameters makes the logic behind which one to toggle more complicated than it has to be, would rather let it be handled in the handleInput methods
	public void toggleSelected(int next, int prev) {
		_menuView.updateSelected(next, prev);
	}

}
