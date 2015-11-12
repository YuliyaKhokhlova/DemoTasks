import static org.junit.Assert.*;

import org.junit.Test;

public class UtilsTest {

	@Test
	public void testIsDouble() {
		assertTrue(NumericUtils.isDoubleFormat("-0.0"));
		assertTrue(NumericUtils.isDoubleFormat("0.0"));
		assertTrue(NumericUtils.isDoubleFormat("-1234567890.098"));
		assertTrue(NumericUtils.isDoubleFormat("1234567890.098"));
		
		assertFalse(NumericUtils.isDoubleFormat("-0.0.0"));
		assertFalse(NumericUtils.isDoubleFormat("2e3.0df0"));
		assertFalse(NumericUtils.isDoubleFormat("-edf.f023"));
	}

	@Test
	public void testIsInt() {
		assertTrue(NumericUtils.isIntFormat("-0"));
		assertTrue(NumericUtils.isIntFormat("5"));
		assertTrue(NumericUtils.isIntFormat("-1234567890"));
		assertTrue(NumericUtils.isIntFormat("1234567890"));
		
		assertFalse(NumericUtils.isIntFormat("234f"));
		assertFalse(NumericUtils.isIntFormat("-234f"));
		assertFalse(NumericUtils.isIntFormat("23.4"));
		assertFalse(NumericUtils.isIntFormat("-2.34f"));
	}
}
