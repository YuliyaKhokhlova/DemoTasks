
public class NumericUtils {
	
	public static String SymbolsInInt = "0123456789-";
	public static String SymbolsInDouble = SymbolsInInt + ".";
	
	public static boolean isDoubleFormat(String value) {
		// minus only in the beginning 
		if (value.indexOf("-") > 0) {
			return false;
		}
		
		// no more than one . symbol
		if (value.indexOf('.') != value.lastIndexOf('.')) {
			return false;
		}
		
		return CheckSymbols(value, SymbolsInDouble);
	}
	
	public static boolean isIntFormat(String value) {
		// minus only in the beginning 
		if (value.indexOf("-") > 0) {
			return false;
		}
		
		return CheckSymbols(value, SymbolsInInt);
	}

	private static boolean CheckSymbols(String value, String appropriateSymbols) {
		for(int i = 0; i < value.length(); i++) {
			String sym = value.substring(i, i + 1);
			if (!appropriateSymbols.contains(sym)) {
				return false;
			}
		}
		return true;
	}
}
