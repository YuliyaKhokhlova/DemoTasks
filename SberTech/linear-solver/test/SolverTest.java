import static org.junit.Assert.*;
import org.junit.Test;

public class SolverTest {

	@Test
	public void test1() {
		double[] expectedSolution = {2.25, -0.875};
		assertTrue(RunSolverOnInput("input.txt", expectedSolution));
	}
	
	@Test
	public void test2() {
		double[] expectedSolution = {2.25, -0.875};
		assertTrue(RunSolverOnInput("input1.txt", expectedSolution));
	}

	public boolean RunSolverOnInput(String inputFileName, double[] expectedSolution) {
		try {
			double[][] extMx = MatrixReader.loadMatrix(inputFileName);
			double[] solution = LinearSolver.Gauss(extMx);
	 		return CompareVectors(solution, expectedSolution);
		}
		catch (Exception e) {
			System.out.println("Error: " + e.getMessage());
		}
		return false;
	}
	
	public boolean CompareVectors(double[] vec1, double[] vec2){
		if (vec1.length != vec2.length) {
			return false;
		}
		
		for (int i = 0; i < vec1.length; i++) {
			if (vec1[i] - vec2[i] >= 0.0001) {
				return false;
			}
		}
		
		return true;
	}
}
