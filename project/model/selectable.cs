namespace abstractClasses;

public abstract class Selectable {

	protected string _name { get; }
	protected bool _selected { get; set; }
	protected string _showSelected => _selected ? "> " : "  ";

	public Selectable(string n) => _name = n;

	public Selectable(string n, bool s) {
		_name = n;
		_selected = s;
	}

	public abstract void printOption();
}

