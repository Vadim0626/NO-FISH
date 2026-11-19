namespace Controller; 
using Model;

class GameLogicController {

	private	IControllable menu = new MainMenuController();
	private ExplorationController exploration;
	private FightController fight;
	private int _gameStatus { get; set; } = 0;
	private bool _isGameOver => _gameStatus == 3;
	private Player player = new(15, 3, 15, 10);

	public GameLogicController() {
		exploration = new ExplorationController(player);
		fight = new FightController(player);
	}

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
			      string? fightLabel = exploration.getEventLabel();
			      if (fightLabel == null) {
				      _gameStatus = (int)gameStatus.Exploration;
				      break;
			      }
			      _gameStatus = fight.prepareFight(fightLabel);
			      break;
			case (int)gameStatus.GameOver:
			      Console.WriteLine("Game over!");
			      break;
			}
	}

	public Player getPlayer() {
		return player;
	}
}
	

