namespace Controller; 
using Model;

class GameLogicController {

	private	IControllable menu = new MainMenuController();
	private IControllable exploration = new ExplorationController();
	private int _gameStatus { get; set; } = 0;
	private bool _isGameOver => _gameStatus == 3;
	private Player player = new(15, 3, 15, 10);

	enum gameStatus {
		Menu,
		Exploration,
		Fighting,
		GameOver
	}	

	public void start() {
		while(!_isGameOver) {
			executeGameState();	
		}
		if(_isGameOver) {
			executeGameState();
		}
	}	

	public void executeGameState() {
		switch(_gameStatus) {
			case (int)gameStatus.Menu:
			      _gameStatus = menu.start();
			      break;
			case (int)gameStatus.Exploration:
			      _gameStatus = exploration.start();
			      break;
			case (int)gameStatus.Fighting:
			      Console.WriteLine("DEBUG: Fighting has Begun");
			      break;
			case (int)gameStatus.GameOver:
			      Console.WriteLine("DEBUG: Game has been quit!");
			      break;
			}
	}

	public Player getPlayer() {
		return player;
	}
}
	

