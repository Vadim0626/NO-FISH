namespace Controller;
using Project.View;

public class MainMenuController {
	MainMenuView mainMenu = new MainMenuView();
	public Boolean isGameStarted;

	public void initialiseMenu() {
		mainMenu.showMenu();
		
		// TODO Fix infinite loop when opening settings
		// Most likely happening because theres no user input to return to menu
		// as such it keeps looping back into the settings since input is still set to 1
		// Might be best to wait until I have more of an idea of if an interactive GUI is doable
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
