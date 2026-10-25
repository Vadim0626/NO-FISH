using abstractClasses;
namespace Model;

public class menuModel : Selectable {
	public menuModel(string n) : base(n) { }

	public override void printOption() {
		Console.WriteLine($"\r {_showSelected} {_name}");
	}
}

