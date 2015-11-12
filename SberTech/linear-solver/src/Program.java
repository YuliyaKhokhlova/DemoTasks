public class Program {

	public static void main(String[] args) {
		if (0 == args.length) {
			System.out.println("Input file not specified");
			return;
		}
		
		String inputFileName = args[0];
		try {
			LinearSolver solver = new LinearSolver(inputFileName);
			solver.PrintSystem();
			solver.Gauss();
			solver.PrintAnswer();
		}
		catch (Exception e) {
			System.out.println("Error: " + e.getMessage());
		}
	}

}
