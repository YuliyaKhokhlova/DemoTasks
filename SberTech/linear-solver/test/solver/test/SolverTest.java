package solver.test;
import static org.junit.Assert.*;
import org.junit.Test;
import solver.core.LinearSolver;
import solver.core.LinearSolver.NoUniqueSolutionException;

public class SolverTest {

	@Test
	public void test2Vars() throws NoUniqueSolutionException {
		double[][] coefs = { 
				{1, -2, 4},
				{3, 2, 5},
			};
		double[] expectedSolution = {2.25, -0.875};
		double[] solution = LinearSolver.Gauss(coefs);
		assertTrue(CompareVectors(solution, expectedSolution));
	}
	
	@Test
	public void test3Vars() throws NoUniqueSolutionException {
		double[][] coefs = { 
				{3,  2, -1,  4},
				{2, -1,  5, 23},
				{1,  7, -1,  5}
			};
		double[] expectedSolution = {2, 1, 4};
		double[] solution = LinearSolver.Gauss(coefs);
		assertTrue(CompareVectors(solution, expectedSolution));
	}

	@Test
	public void test1Var() throws NoUniqueSolutionException {
		double[][] coefs = { 
				{1,  1}
			};
		double[] expectedSolution = {1};
		double[] solution = LinearSolver.Gauss(coefs);
		assertTrue(CompareVectors(solution, expectedSolution));
	}

	@Test
	public void testNoSolution() {
		double[][] coefs = { 
				{1,  1, 1},
				{2,  2, 4},
			};
		
		try {
			LinearSolver.Gauss(coefs);
			fail("Exception 'NoUniqueSolutionException' not caught");
		}
		catch (NoUniqueSolutionException e) {
			return;
		}
		
		fail("Exception 'NoUniqueSolutionException' not caught");
	}

	@Test
	public void testMultSolution() {
		double[][] coefs = { 
				{1,  1, 1},
				{1,  1, 1},
			};

		try {
			LinearSolver.Gauss(coefs);
			fail("Exception 'NoUniqueSolutionException' not caught");
		}
		catch (LinearSolver.NoUniqueSolutionException e) {
			return;
		}
		
		fail("Exception 'NoUniqueSolutionException' not caught");
	}

	public boolean CompareVectors(double[] vec1, double[] vec2){
		if (null == vec1 || null == vec2) {
			return false;
		}
		
		if (vec1.length != vec2.length) {
			return false;
		}
		
		for (int i = 0; i < vec1.length; i++) {
			if (Math.abs(vec1[i] - vec2[i]) >= LinearSolver.Epsilon) {
				return false;
			}
		}
		
		return true;
	}
}
