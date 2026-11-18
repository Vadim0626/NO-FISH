namespace Model; 

class ExplorationModel {

	private string _areaName;

	public string AreaName {
		get => _areaName;
	}

	private bool _selected;

	public bool Selected { 
		get => _selected; 
		set => _selected = value;
	}

	private List<ExplorationEvent> events = new();

	public List<ExplorationEvent> Events {
		get => events;
	}

	public ExplorationModel(string area, ExplorationEvent e1, ExplorationEvent e2, ExplorationEvent e3, bool select) {
		_areaName = area;
		events.Add(e1);
		events.Add(e2);
		events.Add(e3);
		_selected = select;
	}

	public void printEvents() {
		foreach ( ExplorationEvent e in events ) {
			Console.WriteLine($"-- {e.Description.PadRight(30)} (Chance: {e.Chance}%)".PadRight(Console.WindowWidth - 1));
		}
	}

	public ExplorationEvent getEvent(int i) {
		return Events[i];
	}

	public int getEventLength() {
		return Events.Count - 1;
	}

}
