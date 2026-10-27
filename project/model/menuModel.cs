using abstractClasses;
namespace Model;

public class menuModel : Selectable {

	public Boolean Selected {
		get => _selected;
		set => _selected = value;
	}

	public menuModel(string n) : base(n) { }
	public menuModel(string n, Boolean s) : base(n, s) { }

	public override void printOption() {
		Console.WriteLine($"\r {_showSelected} {_name}");
	}
}

