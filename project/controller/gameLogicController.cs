namespace Controller; 

class GameLogicController {

	private	MainMenuController menu = new MainMenuController();
	private int _gameStatus { get; set; } = 0;
	private bool _isGameOver => _gameStatus == 3;

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
			case 0:
			      _gameStatus = menu.start();
			      break;
			case 1:
			      Console.WriteLine("DEBUG: Game has started");
			      break;
			case 2:
			      Console.WriteLine("DEBUG: Exploration has begun");
			      break;
			case 3:
			      Console.WriteLine("DEBUG: Game has been quit!");
			      break;
			}
	}
}
	

