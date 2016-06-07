
public class SortArrayOfStrings {
	public static void Sort(String[] elements) {
		for (int i = 0; i < elements.length - 1; i++) {
			int min = i;
			for (int j = i + 1; j < elements.length; j++) {
				if (elements[j].compareTo(elements[min]) < 0) {
					min = j;
				}
			}
			String temp = elements[i];
			elements[i] = elements[min];
			elements[min] = temp;
		}
	}
}
