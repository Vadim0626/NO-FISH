namespace Project.Controller;
using Project.View;

public class MainḾenuController {
	MainMenuView mainMenu = new MainMenuView();
	public Boolean isGameStarted;

	public void controlMenu() {
		mainMenu.showMenu();
		
		int input = Convert.ToInt16(Console.ReadLine());
		while (!isGameStarted) {
			switch(input) {
				case 1:
					mainMenu.showSettings();
					break;
				case 2:
					Console.WriteLine("Game has been started!");
					isGameStarted = true; 
					break;
			}
		}
	}
}
