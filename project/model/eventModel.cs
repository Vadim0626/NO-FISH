namespace Model;

class ExplorationEvent {

	private string _description; 

	public string Description {
		get => _description;
	}

	private int _chance; 

	public int Chance {
		get => _chance; 
	}

	private string _eventType;

	public string EventType {
		get => _eventType; 
	}

	private string _eventLabel;

	public string EventLabel {
		get => _eventLabel;
	}
	
	// EventType = General Type of Event (Fight, Escape, Scavenging)

	// eventLabel = internal Name of an event (e.g. fight1 to let the controller know to create a fight with the presets of fight1, this could be an enemy with very low HP and ATK since it is the first fight a player will have)
	public ExplorationEvent(string desc, int chance, string e, string eLabel) {
		_description = desc;
		_chance = chance; 
		_eventType = e;
		_eventLabel = eLabel;
	}
}
