namespace Controller; 
using Project.View;

class ExplorationController : IControllable {

	private ExplorationView explore = new();
	private int _left { get; } = Console.CursorLeft;
	private int _top { get; } = Console.CursorTop; 
	private int _explorationIndex {get; set;} = 0;
	private ConsoleKeyInfo _keyInfo { get; set;}

	public int start() {
		Console.SetCursorPosition(_left, _top);
		clearMenu();
		explore.showExploration();	
		do {
			_keyInfo = Console.ReadKey(true);
			if(_keyInfo.Key == ConsoleKey.DownArrow) {
				handleDownInput(_explorationIndex);
			}
			if(_keyInfo.Key == ConsoleKey.UpArrow) {
				handleUpInput(_explorationIndex); 
			}
			Console.SetCursorPosition(_left, _top);
			explore.showExploration();
		}
		while(_keyInfo.Key != ConsoleKey.Enter);
		return 3;
	}

	public void clearMenu() {
		Console.SetCursorPosition(_left, _top);
		for(int i = 0; i < 20; i++) {
			Console.Write(new string(' ', Console.WindowWidth));
		}
		Console.SetCursorPosition(_left, _top);
	}

	public void handleUpInput(int i) {
		toggleSelected(i);
		i--;
		i = checkIndex(i);
		toggleSelected(i);
		_explorationIndex = i;
	}

	public void handleDownInput(int i) {
		toggleSelected(i);
		i++;
		i = checkIndex(i);
		toggleSelected(i);
		_explorationIndex = i;
	}

	public void toggleSelected(int i) {
		explore.updateSelected(i);
	}

	public int checkIndex(int i) {
		bool isIndexInBounds = explore.validateIndex(i); 
		if(i >= 1 && !isIndexInBounds) {
			i = 0;
		}
		else if(i <= 0 && !isIndexInBounds) {
			i = explore.getListLength();
		}
		return i;
	}
}
