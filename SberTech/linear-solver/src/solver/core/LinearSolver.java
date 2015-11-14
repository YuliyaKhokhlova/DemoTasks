package solver.core;
// Solver for Linear Algebraic Equations System
// Ax=b
// A - matrix (n x n)
// b, x - vectors (n x 1)
// Extended matrix (A|b) - (n x n+1)
public class LinearSolver {
	@SuppressWarnings("serial")
	public static class NoUniqueSolutionException extends Exception {
		public NoUniqueSolutionException(String message) {
			super(message);
		}
	}
	
	public static final double Epsilon = 0.0001;
	public static double[] Gauss(double[][] extendedMatrix) throws NoUniqueSolutionException {
		int VariablesNumber = extendedMatrix.length;
		
		// i - leading row/column
		for(int i = 0; i < VariablesNumber; i++) {
			double div = extendedMatrix[i][i];

			// Make leading element not null, if required
			if (Math.abs(div) < Epsilon) {
				int rowToAdd = RowWithNotNullValueOnColumn(extendedMatrix, i);
				
				if (rowToAdd < i) {
					throw new NoUniqueSolutionException("System doesn't have unique solution");
				}
				
				SumMatrixRows(extendedMatrix, i, 1, rowToAdd, 1);
			}
			div = extendedMatrix[i][i];

			// Make leading element equal to 1
			for (int j = 0; j <= VariablesNumber; j++) {
				extendedMatrix[i][j] /= div;
			}
			
			// Subtract leading row from the other rows
			for (int r = 0; r < VariablesNumber; r++) {
				if (i == r) continue;
				
				double mult = extendedMatrix[r][i];
				SumMatrixRows(extendedMatrix, r, 1, i, -mult);
			}
		}
		
		// There is row containing only 0s => no unique solution
		boolean nulRowFound = true;
		for(int i = 0; i < VariablesNumber; i++) {
			nulRowFound = true;
			for (int j = 0; j < VariablesNumber; j++) {
				if (Math.abs(extendedMatrix[i][j]) >= Epsilon) {
					nulRowFound = false;
					break;
				}
			}
			
			if (nulRowFound) {
				break;
			}
		}
		
		if (nulRowFound) {
			throw new NoUniqueSolutionException("System doesn't have unique solution");
		}

		double[] solution = new double[VariablesNumber];
		for(int i = 0; i < VariablesNumber; i++) {
			solution[i] = extendedMatrix[i][VariablesNumber];
		}
		
		return solution;
	}
	
	private static void SumMatrixRows(double[][] matrix, int row1, double mult1, int row2, double mult2) {
		if (null == matrix) {
			return;
		}

		for (int j = 0; j < matrix[0].length; j++) {
			matrix[row1][j] = mult1 * matrix[row1][j] + mult2 * matrix[row2][j];
		}
	}
	
	private static int RowWithNotNullValueOnColumn(double[][] matrix, int column) {
		if (null == matrix || column >=matrix[0].length) {
			return -1;
		}
		
		for (int i = matrix.length - 1; i >= 0; i-- ) {
			if (matrix[i][column] >= Epsilon) {
				return i;
			}
		}
		return -1;
	}
}
