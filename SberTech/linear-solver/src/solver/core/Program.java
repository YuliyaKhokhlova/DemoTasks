package solver.core;

import solver.core.LinearSolver.NoUniqueSolutionException;

public class Program {

	public static void main(String[] args) {
		if (0 == args.length) {
			System.out.println("Input file not specified");
			return;
		}
		
		String inputFileName = args[0];
		try {
			double[][] extMx = MatrixReader.loadMatrix(inputFileName);
			printSystem(extMx);
			
			double[] solution = LinearSolver.Gauss(extMx);
			printVector(solution);
		}
		catch (NoUniqueSolutionException e) {
			System.out.println(e.getMessage());
		}
		catch (Exception e) {
			System.out.println("Error: " + e.getMessage());
		}
	}

	public static void printVector(double[] vector) {
		for (int i = 0; i < vector.length; i++) {
			System.out.print("x" + (i+1) + "=" + vector[i] + " ");
		}
		System.out.println("");		
	}

	public static void printSystem(double[][] extendedMatrix) {
		for(int i = 0; i < extendedMatrix.length; i++) {
			for (int j = 0; j < extendedMatrix[0].length - 1; j++) {
				System.out.print((extendedMatrix[i][j] >= 0 ? "+" : "") + extendedMatrix[i][j] + "x" + (j+1) + " ");
			}
			System.out.println("= " + extendedMatrix[i][extendedMatrix.length]);
		}
	}

}
