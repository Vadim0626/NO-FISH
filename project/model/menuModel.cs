using abstractClasses;
namespace Model;

public class menuModel : Selectable {

	public bool Selected {
		get => _selected;
		set => _selected = value;
	}

	public menuModel(string n) : base(n) { }
	public menuModel(string n, bool s) : base(n, s) { }

	public override void printOption() {
		Console.WriteLine($"\r {_showSelected} {_name}");
	}
}

