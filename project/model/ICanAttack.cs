namespace Model;

interface ICanAttack {
	
	int health { get; set; }
	int strength { get; set; }
	int maxHealth { get; }

	public void attack(ICanAttack attackedCharacter);
	public void heal(int healAmount);
}
