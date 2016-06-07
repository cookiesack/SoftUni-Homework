import java.util.Scanner;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		PrintHometown.Print();
		CurrentDateTime.Print();
		Scanner s = new Scanner(System.in);
		 SumTwoNumbers.Sum(s.nextInt(), s.nextInt());
		int numberOfStrings = s.nextInt();
		s.nextLine();
		String[] input = new String[numberOfStrings];
		for (int i = 0; i < numberOfStrings; i++) {
			input[i] = s.nextLine();
		}
		SortArrayOfStrings.Sort(input);
		for (String str : input) {
			System.out.println(str);
		}
	}
}
