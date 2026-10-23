using Controller;
namespace test {
	class testClass {
		public string name;
		public Boolean selected;
		public string showSelected => selected ? "> " : "  ";

		public testClass(string n, Boolean b) {
			name = n;
			selected = b;
		}
	
		public void printMenu() {
			Console.WriteLine($"{showSelected} {name}");
		}
	}

	class MainProgram {

		static void Main() {	
			ConsoleKeyInfo keyInfo;
			testClass class1 = new("Main Menu", true);
			testClass class2 = new("Options", false);
			class1.printMenu();
			class2.printMenu();
			do {
				keyInfo = Console.ReadKey();
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
