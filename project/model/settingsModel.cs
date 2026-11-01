namespace Model;

class SettingsModel : Selectable {
	
	protected bool _isToggled;
	protected string _showToggled => _isToggled ? "[ x ]" : "[   ]";

	public SettingsModel(string n) : base(n) { }
	public SettingsModel(string n, bool b) : base(n, b) { }
	public SettingsModel(string n, bool b, bool b2) : base (n,b) {
		_isToggled = b2;
	}

	public override void printOption() {
		Console.WriteLine($"\r {_showSelected} {_showToggled} {_name}");
	}
}
