namespace Model;
using abstractClasses;

class SettingsModel : Selectable {
	
	protected bool isToggled;
	protected string _showToggled => isToggled ? "[ x ]" : "[   ]";

	public override void printOption() {
		Console.WriteLine($"\r {_showSelected} {_showToggled} {_name}");
	}

	public SettingsModel(string n) : base(n) { }
	public SettingsModel(string n, bool b) : base(n, b) { }
	public SettingsModel(string n, bool b, bool b2) {
		_name = n;
		_selected = b;
		_isToggled = b2;
	}

}
