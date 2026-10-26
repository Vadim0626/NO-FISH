using Model;
using System.Collections;
namespace Project.View;

class MainMenuView {

	private List<menuModel> options = new(); 

	public MainMenuView() {
		options.Add(new menuModel("Start", true));
		options.Add(new menuModel("Options"));
		options.Add(new menuModel("Quit"));
	}

	public void showMenu() {
		Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
		foreach (menuModel opt in options) {
			opt.printOption();
		}
			
	}

	public void showSettings() {
	}

	//TODO: Figure out how to let MainMenuView update attributes it has inherited
	public void updateSelected(int cur, int prev) {
		options[cur]._selected = true;
		options[prev]._selected = false;
	}

	// Check if the index is still in range of the List
	// i can either go into the negatives (i < 0) or beyond the length of the array (i > options.Count - 1)
	public Boolean validateIndex(int i) {
		if(i < 0 || i > getListLength()) {
			return false;
		}
		return true;
	}

	public int getListLength() {
		return options.Count - 1;
	}
}
