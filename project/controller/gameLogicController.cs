namespace Controller; 

class GameLogicController {

	private	MainMenuController menu = new MainMenuController();
	private int _gameStatus { get; set; } = 0;
	private bool _isGameOver => _gameStatus == 3 || _gameStatus == 1;

	enum gameStatus {
		Menu = 0,
		Exploration = 1,
		Fighting = 2,
		GameOver = 3
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
			      Console.WriteLine("DEBUG: Game (and exploration) has started");
			      break;
			case (int)gameStatus.Fighting:
			      Console.WriteLine("DEBUG: Fighting has Begun");
			      break;
			case (int)gameStatus.GameOver:
			      Console.WriteLine("DEBUG: Game has been quit!");
			      break;
			}
	}
}
	

