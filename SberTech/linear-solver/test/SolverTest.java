import static org.junit.Assert.*;
import org.junit.Test;

public class SolverTest {

	@Test
	public void test1() {
		
		assertTrue(RunSolverOnInput("input.txt"));
	}
	
	@Test
	public void test2() {
		assertTrue(RunSolverOnInput("input1.txt"));
	}

	public boolean RunSolverOnInput(String inputFileName) {
		LinearSolver solver = null;
		try {
			solver = new LinearSolver(inputFileName);
			solver.Gauss();
		}
		catch (Exception e) {
			
		}
		double[] expectedSolution = {2.25, -0.875};
 		return CompareVectors(solver.getSolution(), expectedSolution);
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
