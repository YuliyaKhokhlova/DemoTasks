package solver.test;
import static org.junit.Assert.*;

import java.io.IOException;

import org.junit.Test;

import solver.core.LinearSolver;
import solver.core.MatrixReader;
import solver.core.MatrixReader.MatrixWrongFormatException;

public class ReaderTest {

	@Test
	public void test2x2Matrix() throws IOException {
		double[][] expectedMx = {
				{1, -2, 4},
				{3, 2, 5},
		};
		double[][] mx = MatrixReader.loadMatrix("input.txt");
		assertTrue(CompareMatrices(mx, expectedMx));
	}

	@Test
	public void test3x3Matrix() throws IOException {
		double[][] expectedMx = {
				{3,  2, -1,  4},
				{2, -1,  5, 23},
				{1,  7, -1,  5}
		};
		double[][] mx = MatrixReader.loadMatrix("input1.txt");
		assertTrue(CompareMatrices(mx, expectedMx));
	}

	@Test
	public void testEmptyFile() throws IOException {
		try {
			MatrixReader.loadMatrix("input2.txt");
			fail("Matrix load succeded");
		}
		catch (MatrixWrongFormatException e) {
			return;
		}
	}

	@Test
	public void testNotANumberRowsCount() throws IOException {
		try {
			MatrixReader.loadMatrix("input3.txt");
			fail("Matrix load succeded");
		}
		catch (MatrixWrongFormatException e) {
			return;
		}
	}

	@Test
	public void testNotANumberMatrixElement() throws IOException {
		try {
			MatrixReader.loadMatrix("input4.txt");
			fail("Matrix load succeded");
		}
		catch (MatrixWrongFormatException e) {
			return;
		}
	}

	private boolean CompareMatrices(double[][] mx1, double[][] mx2) {
		if (null == mx1 || null == mx2) {
			return false;
		}
		
		if (mx1.length != mx2.length || mx1[0].length != mx2[0].length) {
			return false;
		}
		
		for (int i = 0; i < mx1.length; i++) {
			for (int j = 0; j < mx1[0].length; j++) {
				if (Math.abs(mx1[i][j]-mx2[i][j]) >= LinearSolver.Epsilon) {
					return false;
				}
			}
		}
		return true;
	}
}
