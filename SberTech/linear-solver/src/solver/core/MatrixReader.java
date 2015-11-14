package solver.core;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class MatrixReader {
	
	public static class MatrixWrongFormatException extends IOException {
		public MatrixWrongFormatException(String message) {
			super(message);
		}
	}
	
	public static double[][] loadMatrix(String dataFileName) throws IOException, MatrixWrongFormatException {
		BufferedReader br = new BufferedReader(new FileReader(dataFileName));
		
		// line 1: number of variables
		String line = br.readLine();
		if (null == line) {
			br.close();
			throw new MatrixWrongFormatException("Inappropriate input file format: matrix size not found");
		}
		
		int variablesNumber;
		try {
			variablesNumber = Integer.parseInt(line);
		}
		catch (NumberFormatException e) {
			br.close();
			throw new MatrixWrongFormatException("Inappropriate input file format: matrix contains non-numeric element: " + line);
		}
		
		if (variablesNumber < 1) {
			br.close();
			throw new MatrixWrongFormatException("Inappropriate input file format: non-positive number of rows/columns: " + variablesNumber);
		}
		
		double[][] matrix = new double[variablesNumber][variablesNumber + 1];
			
		// lines 2-(N+1): coefs of linear equations
		line = br.readLine();
		for (int row = 0; row < variablesNumber; row++) {
			if (null == line) {
				
			}
			
			String[] coef = line.split(" "); 
			for(int col = 0; col < coef.length; col++ ) {
				try {
					matrix[row][col] = Double.parseDouble(coef[col]);
				}
				catch (NumberFormatException e) {
					br.close();
					throw new MatrixWrongFormatException("Inappropriate input file format: matrix contains non-numeric element: " + coef);
				}
			}
			
			line = br.readLine();
		}
		
		br.close();
		return matrix;
	}

}
