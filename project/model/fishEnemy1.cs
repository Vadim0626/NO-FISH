namespace Model;

class FishEnemy : ICanAttack {

	public int health { get; set; }
	public int maxHealth { get; }
	public int strength { get; set; }

	public FishEnemy(int hp, int str, int maxhp) {
		health = hp;
		strength = str;
		maxHealth = maxhp;
	}

	public void heal(int healAmount) {
		int healedHealth = health + healAmount;
		if (healedHealth > maxHealth) {
			health = maxHealth;
		}
		else {
			health = healedHealth;
		}
	}
		

	public void attack(ICanAttack attackedCharacter) {
		Random missChance = new Random();
		int miss = missChance.Next(1, 101);
		if(miss <= 75) {
			attackedCharacter.health -= strength;
			Console.WriteLine($"\nPlayer took {strength} damage!");
		}
		else {
			Console.WriteLine("\nAttack missed! Player took no damage");
		}
	}
}
