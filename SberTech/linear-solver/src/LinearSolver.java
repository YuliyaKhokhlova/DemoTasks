import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

// Solver for Linear Algebraic Equations System
// Ax=b
// A - matrix (n x n)
// b, x - vectors (n x 1)
public class LinearSolver {
	
	private int VariablesNumber;
	public int getVariablesNumber() {
		return VariablesNumber;
	}
	
	private double[][] Coefs; // Extended matrix (A|b) - (n x n+1)
	public double[][] getCoefs() {
		return Coefs;
	}
	
	private double[] Solution;
	public double[] getSolution() {
		return Solution;
	}
	
	LinearSolver(String dataFileName) throws IOException {
		BufferedReader br = new BufferedReader(new FileReader(dataFileName));
			
		// line 1: number of variables
		String line = br.readLine();
		if (null == line) {
			br.close();
			throw new IOException("Inappropriate input file format");
		}
		
		if (!NumericUtils.isIntFormat(line))
		{
			br.close();
			throw new IOException("Inappropriate input: " + line + ". Integer expected");
		}
		VariablesNumber = Integer.parseInt(line);
		Coefs = new double[VariablesNumber][VariablesNumber + 1];
		Solution = new double[VariablesNumber];
			
		// lines 2-(N+1): coefs of linear equations
		line = br.readLine();
		for (int row = 0; row < VariablesNumber && null != line; row++) {
			String[] coef = line.split(" "); 
			for(int col = 0; col < coef.length; col++ ) {
				if (!NumericUtils.isDoubleFormat(coef[col])) {
					br.close();
					throw new IOException("Inappropriate input: " + line + ". Double expected");
				}
				Coefs[row][col] = Double.parseDouble(coef[col]); //TODO: exception handling
			}
			
			line = br.readLine();
		}
		
		br.close();
	}

	public void Gauss() throws Exception {
		// i - leading row/column
		for(int i = 0; i < VariablesNumber; i++) {

			// Make leading element equal to 1
			double div = Coefs[i][i];
			for (int j = 0; j <= VariablesNumber; j++) {
				//TODO: what if leading element is 0???
				Coefs[i][j] /= div; 
			}
			
			// Subtract leading row from the other rows
			for (int r = 0; r < VariablesNumber; r++) {
				if (i == r) continue;
				
				double mult = Coefs[r][i];
				for (int j = 0; j <= VariablesNumber; j++) {
					Coefs[r][j] -= mult * Coefs[i][j];
				}
			}
		}
		
		// Row contains only 0s => no unique solution
		boolean nulRowFound = true;
		for(int i = 0; i < VariablesNumber; i++) {
			nulRowFound = true;
			for (int j = 0; j < VariablesNumber; j++) {
				if (Math.abs(Coefs[i][j]) >= 0.0001) {
					nulRowFound = false;
					break;
				}
			}
			
			if (nulRowFound) {
				break;
			}
		}
		
		if (nulRowFound) {
			throw new Exception("System doesn't have unique solution");
		}

		for(int i = 0; i < VariablesNumber; i++) {
			Solution[i] = Coefs[i][VariablesNumber];
		}
	}
	
	public void PrintAnswer() {
		for (int i = 0; i < VariablesNumber; i++) {
			System.out.print("x" + (i+1) + "=" + Solution[i] + " ");
		}
		System.out.println("");		
	}

	public void PrintSystem() {
		for(int i = 0; i < VariablesNumber; i++) {
			for (int j = 0; j < VariablesNumber; j++) {
				System.out.print((Coefs[i][j] >= 0 ? "+" : "") + Coefs[i][j] + "x" + (j+1) + " ");
			}
			System.out.println("= " + Coefs[i][VariablesNumber]);
		}
	}

}
