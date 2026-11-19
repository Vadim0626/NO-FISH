namespace Controller;
using Project.View;
using Model;

class FightController {

	private FightView fightView = new();
	private Player player;
	private int _left { get; } = Console.CursorLeft;
	private int _top { get; } = Console.CursorTop;
	private int _fightIndex { get; set; } = 0;
	private ConsoleKeyInfo _keyInfo { get; set; }
	private bool isPlayerTurnOver = false;
	private bool hasEscaped = false;
	private bool hasLost = false;

	public FightController(Player p) {
		player = p;
	}

	public int prepareFight(string eventLabel) {
		ICanAttack? enemy = null;
		isPlayerTurnOver = false;
		hasEscaped = false;
		hasLost = false;
		switch(eventLabel) {
			case "fight1":
				enemy = new FishEnemy(10, 2, 10);
				break;
			case "esc1":
				enemy = new FishEnemy(100, 4, 100);
				break;
			}
		if(enemy == null) {
			Console.WriteLine($"DEBUG: Problem preparing the fight! {eventLabel}");
			return 1;
		}
		return start(enemy);
	}

	public int start(ICanAttack enemy) {
		bool isFightOver = false;
		fightView.showOptions();
		fightView.showHealth(player, enemy);

		do {
			while(!isPlayerTurnOver) {
				_keyInfo = Console.ReadKey(true);
				if(_keyInfo.Key == ConsoleKey.DownArrow) {
					handleDownInput(_fightIndex);
				}
				if(_keyInfo.Key == ConsoleKey.UpArrow) {
					handleUpInput(_fightIndex);
				}
				if(_keyInfo.Key == ConsoleKey.Enter) {
					handleSelectedOption(_fightIndex, enemy);
				}
				if(!isPlayerTurnOver) {
					Console.SetCursorPosition(_left, _top);
					fightView.showOptions();
					fightView.showHealth(player, enemy);
				}
			}
			if(hasEscaped) {
				Console.WriteLine("Press any key to return to exploration!");
				Console.ReadKey(true);
				return 1;
			}

			if(enemy.Health <= 0) {
				isFightOver = true;
			}
			else {
				enemy.attack(player);
				Console.WriteLine($"Press any button to return");
				Console.ReadKey(true);
				isPlayerTurnOver = false;
				if(player.Health <= 0) {
					hasLost = true;
					isFightOver = true;
				}
			}
			clearMenu();
			fightView.showOptions();
			fightView.showHealth(player, enemy);
		}
		while(!isFightOver);
		if(hasLost) {
			clearMenu();
			return 3;
		}
		Random rnd = new Random();
		int gold = rnd.Next(25,51);
		player.Gold += gold;

		Console.WriteLine($"\nYou have won!");
		Console.WriteLine($"Obtained {gold} gold!");
		Console.WriteLine("Press any key to return to exploration!");
		Console.ReadKey(true);
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
		_fightIndex = i;
	}

	public void handleDownInput(int i) {
		toggleSelected(i);
		i++;
		i = checkIndex(i);
		toggleSelected(i);
		_fightIndex = i;
	}

	public void toggleSelected(int i) {
		fightView.updateSelected(i);
	}

	public int checkIndex(int i) {
		bool isIndexInBounds = fightView.validateIndex(i);
		if(i >= 1 && !isIndexInBounds) {
			i = 0;
		}
		else if(i <= 0 && !isIndexInBounds) {
			i = fightView.getListLength();
		}
		return i;
	}

	public void handleSelectedOption(int i, ICanAttack enemy) {
		switch(i) {
			case 0: 
				player.attack(enemy);
				Console.WriteLine("Press any button to return!");
				Console.ReadKey(true);
				isPlayerTurnOver = true;
				break;
			case 1:
				if(player.Inventory.Count == 0) {
					Console.WriteLine("You have no healing potions left!");
					Console.WriteLine("Press any button to return");
					Console.ReadKey(true);
					clearMenu();
				}
				else {	
					Console.WriteLine("Healed for 5 HP!");
					player.heal(5);
					player.remove("Healing Potion");
					Console.WriteLine("Press any Button to return");
					Console.ReadKey(true);
					clearMenu();
				}
				break;
			case 2:
				Random rnd = new Random();
				int escape = rnd.Next(1, 101);
				if(escape > 50) {
					Console.WriteLine("Escaped successfully!");
					hasEscaped = true;
				}
				else {
					Console.WriteLine("You didn't manage to escape!");
				}
				isPlayerTurnOver = true;
				break;
		}
	}
}
