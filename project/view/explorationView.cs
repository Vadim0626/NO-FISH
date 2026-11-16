namespace Project.View;
using Model;

class ExplorationView {

	// Clarification:
	// - Areas are explorable Locations in a Floor
	// - Each Floor will have a varying amount of Areas
	// - In later stages of implementation there would be bossfights at the end of a Floor, beating that boss would lead to the next Floor

	// Initialise area 1
	static ExplorationEvent e1 = new("Fight a Fish!", 60, "Fight", "fight1");
	static ExplorationEvent e2 = new("FInd a healing item", 30, "Scavenging", "scavHeal");
	static ExplorationEvent e3 = new("Find a pile of gold", 10, "Scavenging", "scavGold");
	static ExplorationModel area1 = new("The Beach", e1, e2, e3, true);

	// Initialise area 2
	static ExplorationEvent e4 = new("Encounter a dangerous Monster", 70, "Escape", "esc1");
	static ExplorationEvent e5 = new("Find a crate of healing items", 20, "Scavenging", "scavHeal2");
	static ExplorationEvent e6 = new("Find a large pile of gold", 10, "Scavenging", "scavGold2");
	static ExplorationModel area2 = new("The Forest", e4, e5, e6, false);

	private List <ExplorationModel> areas = new();
	
	public ExplorationView() {
		areas.Add(area1);
		areas.Add(area2);
	}

	public void showExploration() {
		foreach (ExplorationModel area in areas) {
			if(area.Selected) {
				Console.Write("=>");
			}
			Console.WriteLine(area.AreaName);

			if(area.Selected) {
				area.printEvents();
			}
		}
		Console.WriteLine($"\n <== Press Enter to select an Event ==>");
	}
		
}
