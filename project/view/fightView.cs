namespace Project.View;
using Model;

class FightView {

	private List<Selectable> _options = new();

	public FightView() {
		_options.Add(new menuModel("Attack", true));
		_options.Add(new menuModel("Heal"));
		_options.Add(new menuModel("Escape"));
	}

	public void showOptions() {
		Console.WriteLine("=== Choose an Action: ===");
		foreach (Selectable opt in _options) {
			opt.printOption();
		}
	}

	public void showHealth(ICanAttack player, ICanAttack enemy) {
		Console.WriteLine($"\nPlayer's health: {player.Health}");
		Console.WriteLine($"Enemy health: {enemy.Health}");
	}

	public bool validateIndex(int i) {
		if(i < 0 || i > _options.Count - 1) {
			return false;
		}
		return true;
	}

	public void updateSelected(int i) {
		_options[i].Selected = !_options[i].Selected;
	}

	public int getListLength() {
		return _options.Count - 1;
	}

}
