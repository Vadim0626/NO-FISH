using Controller;
using Project.View;
class MainProgram {

	static void Main() {
		MainMenuView test = new MainMenuView();
		test.showMenu();
		MainMenuController testController = new MainMenuController();
	}
}
