namespace Controller;
using Project.View;
using Model;

class ExplorationController : IControllable {

	private ExplorationView explore = new();
	private string? _explorationEventType { get; set; }
	private string? _explorationEventLabel { get; set; }
	private int _left { get; } = Console.CursorLeft;
	private int _top { get; } = Console.CursorTop; 
	private int _explorationIndex {get; set;} = 0;
	private ConsoleKeyInfo _keyInfo { get; set;}
	private Player player; 

	public ExplorationController(Player p) {
		player = p;
	}

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
		rollEvent(_explorationIndex);

		clearMenu();
		switch (_explorationEventType) {
			case "Fight":
				return 2;
			case "Scavenging":
				initiateScavenging();
				break;
			case "Escape":
				return 2;
		}
		return 1;
	}

	public void clearMenu() {
		Console.SetCursorPosition(_left, _top);
		for(int i = 0; i < 20; i++) {
			Console.Write(new string(' ', Console.WindowWidth - 1));
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

	public void rollEvent(int exploreIndex) {
		ExplorationModel selectedArea = explore.getArea(exploreIndex);
		Random randNum = new();
		int rolledNum = randNum.Next(1, 101);
		int eventChance = 0;
		ExplorationEvent currentEvent = selectedArea.getEvent(0);

		for(int i = 0; i < selectedArea.getEventLength(); i++) {
			currentEvent = selectedArea.getEvent(i);
			eventChance += currentEvent.Chance;
			if(rolledNum <= eventChance) {
				break;
			}
		}
		_explorationEventType = currentEvent.EventType;
		_explorationEventLabel = currentEvent.EventLabel;
	}

	public void initiateScavenging() {
		switch (_explorationEventLabel) {
			case "scavHeal":
				player.give("Healing Potion");
				Console.WriteLine("Found a Healing Potion!");
				break;
			case "scavHeal2":
				player.give("Healing Potion");
				player.give("Healing Potion");
				Console.WriteLine("Found 2 Healing Potions!");
				break;
			case "scavGold":
				player.Gold += 50;
				Console.WriteLine("Found a small pile of 50 gold!");
				break;
			case "scavGold2":
				player.Gold += 150;
				Console.WriteLine("Found a large pile of gold!");
				break;
		}
		Console.WriteLine("Press any Key to return");
		Console.ReadKey(true);
		clearMenu();
	}

	public string? getEventLabel() {
		return _explorationEventLabel;
	}

}
