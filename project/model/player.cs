namespace Model; 

class Player : ICanAttack {

	public int health { get; set; }
	public int maxHealth { get; }
	public int strength { get; set; }

	public Player(int hp, int str, int maxhp) {
		health = hp;
		strength = str;
		maxHealth = maxhp;
	}

	public void attack(ICanAttack attackedcharacter) {
		attackedcharacter.health -= strength;
	}

	public void heal(int healAmount) {
		int healedHealth = health + healAmount;
		if(healedHealth > maxHealth) {
			health = maxHealth;
		}
		else {
			health = healedHealth;
		}
	}
		

}
