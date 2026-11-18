namespace Model; 

class Player : ICanAttack {

	public int health { get; set; }
	public int maxHealth { get; }
	public int strength { get; set; }
	private int critRate { get; set; }
	private int gold { get; set; }
	public int Gold {
		get => gold;
		set => gold = value;
	}
	private List<String> _inventory = new();
	public List<String> Inventory {
		get { return Inventory; }
		set { _inventory = value; }
	}

	public Player(int hp, int str, int maxhp, int cr) {
		health = hp;
		strength = str;
		maxHealth = maxhp;
		critRate = cr;
		gold = 50;
	}

	public void attack(ICanAttack attackedcharacter) {
		Random crit = new Random();
		int criticalHit = crit.Next(1, 101);
		if(criticalHit >= 100 - critRate) {
			Console.WriteLine("A critical hit!");
			attackedcharacter.health -= 2 * strength;
		} else {
			attackedcharacter.health -= strength;
		}
	}

	public void heal(int healAmount) {
		int healedHealth = health + healAmount;
		if(healedHealth > maxHealth) {
			health = maxHealth;
		} else {
			health = healedHealth;
		}
	}

	public void give(string item) {
		Inventory.Add(item);
	}

	public void remove(string item) {
		foreach(string i in _inventory) {
			if(i == item) {
				Inventory.Remove(item);
				break;
			}
		}
	}
}

		


