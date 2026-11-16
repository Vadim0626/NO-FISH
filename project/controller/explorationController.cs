namespace Controller; 
using Project.View;

class ExplorationController : IControllable {

	private ExplorationView explore = new();
	private int _left { get; } = Console.CursorLeft;
	private int _top { get; } = Console.CursorTop; 

	public int start() {
		clearMenu();
		explore.showExploration();	
		return 3;
	}

	public void clearMenu() {
		Console.SetCursorPosition(_left, _top);
		for(int i = 0; i < 20; i++) {
			Console.Write(new string(' ', Console.WindowWidth));
		}
		Console.SetCursorPosition(_left, _top);
	}
}
