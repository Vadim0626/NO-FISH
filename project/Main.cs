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
			Console.WriteLine($"\r {showSelected} {selected}"); 
	}

	class MainProgram {

		static void Main() {	
			ConsoleKeyInfo keyInfo;
			int selectedIndex = 0;
			testClass class1 = new("Main Menu", true);
			testClass class2 = new("Options", false);
			testClass class3 = new("Quit", false);
			List<testClass> menus = new List<testClass>();
			menus.Add(class1);
			menus.Add(class2);
			menus.Add(class3);
			class1.printMenu();
			class2.printMenu();
			class3.printMenu();
			do {
				keyInfo = Console.ReadKey();
				class1.printMenu();
				class2.printMenu();
				class3.printMenu();
				if (keyInfo.Key == ConsoleKey.DownArrow) {
					menus[selectedIndex].selected = false;
					selectedIndex++;
					menus[selectedIndex].selected = true;
				}
				} while(keyInfo.Key != ConsoleKey.Enter);
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

