namespace abstractClasses;

public abstract class Selectable {

	protected string _name { get; }
	protected Boolean _selected { get; set; }
	protected string _showSelected => _selected ? "> " : "   ";

	public Selectable(string n) => _name = n;

	public abstract void printOption();
}

