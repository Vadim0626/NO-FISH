using Controller;
using System.Collections;
namespace test {
	class testClass {
		public string name;
		public Boolean selected { get; set; }
		public string showSelected => selected ? "> " : "  ";

		public testClass(string n, Boolean b) {
			name = n;
			selected = b;
		}
	
		public void printMenu() {
			Console.WriteLine($"\r {showSelected} {name}"); 
	}

	class MainProgram {

		static void Main() {
			int startCol = Console.CursorLeft;
			int startRow = Console.CursorTop;
			ConsoleKeyInfo keyInfo;
			int selectedIndex = 0;

			testClass class1 = new("Start the Game!", true);
			testClass class2 = new("Options", false);
			testClass class3 = new("Quit", false);
			List<testClass> menus = new List<testClass>();

			menus.Add(class1);
			menus.Add(class2);
			menus.Add(class3);
			// Initial printing of the menus.
			class1.printMenu();
			class2.printMenu();
			class3.printMenu();
			do {
				keyInfo = Console.ReadKey(false);
				if (keyInfo.Key == ConsoleKey.DownArrow) {
					handleDownInput(ref menus, ref selectedIndex);	
				}
				if (keyInfo.Key == ConsoleKey.UpArrow) {
					handleUpInput(ref menus, ref selectedIndex);
				}
				Console.SetCursorPosition(startCol, startRow);
				class1.printMenu();
				class2.printMenu();
				class3.printMenu();

				} while(keyInfo.Key != ConsoleKey.Enter);
			switch(selectedIndex) {
				case 0:
					gameSelected();
					break;
				case 1: 
					optionSelected();
					break;
				case 2:
					quitSelected();
					break;
			}

			static void handleDownInput(ref List<testClass> t, ref int index) {
				t[index].selected = false;
				Boolean nextIndexBiggerThanCount = index + 1 > t.Count - 1;
				index = nextIndexBiggerThanCount ? index = 0 : index += 1;
				t[index].selected = true;
			}

			static void handleUpInput(ref List<testClass> t, ref int index) {
				t[index].selected = false; 
				Boolean nextIndexLessThanCount = index - 1 > t.Count - 1;
				index = nextIndexLessThanCount ? index = t.Count - 1 : index -= 1;
				t[index].selected = true;
			}

			static void optionSelected() {
				Console.WriteLine("Options have been selected");
			}

			static void gameSelected() {
				Console.WriteLine("Start of game has been selected");
			}
			static void quitSelected() {
				Console.WriteLine("Quit has been selected");
			}

	}
}
}
}

