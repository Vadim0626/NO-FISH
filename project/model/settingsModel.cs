namespace Model;
using abstractClasses;

class SettingsModel : Selectable {

	new protected string _showSelected => _selected ? "[ x ]" : "[   ]";

	public override void printOption() {
		Console.WriteLine($"\r {_showSelected} {_name}");
	}

	public SettingsModel(string n) : base(n) { }

}
