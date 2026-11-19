namespace Model;

interface ICanAttack {
	
	int health { get; set; }
	int Health {
		get => health;
		set => health = value;
	}
	int strength { get; set; }
	int Strength {
		get => strength;
		set => strength = value;
	}
	int maxHealth { get; }

	public void attack(ICanAttack attackedCharacter);
	public void heal(int healAmount);
}
