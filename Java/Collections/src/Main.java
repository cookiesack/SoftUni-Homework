import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;
import java.util.Collections;
import java.util.Dictionary;
import java.util.HashMap;
import java.util.Map;

public class Main {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		// Problem 01
		/*
		int n = input.nextInt();
		int[] numbers = new int[n];
		for (int i = 0; i < n; i++) {
			numbers[i] = input.nextInt();
		}
		Arrays.sort(numbers);
		for (int i = 0; i < n; i++) {
			System.out.print(numbers[i]);
			if (i != n - 1)
				System.out.print(" ");
		}
		*/

		// Problem 02
		/*
		String[] strings = input.nextLine().split(" ");
		String previous = strings[0];
		System.out.print(previous + " ");
		for (int i = 1; i < strings.length; i++) {
			if (!strings[i].equals(previous)) {
				System.out.println();
			}
			System.out.print(strings[i] + " ");
			previous = strings[i];
		}
		*/
		
		// Problem 03
		/*
		String[] strings = input.nextLine().split(" ");
		String previous = strings[0];
		int count = 1;
		int maxCount = 1;
		String max = strings[0];
		for (int i = 1; i < strings.length; i++) {
			if (strings[i].equals(previous)) {
				count++;
			} else {
				count = 1;
			}
			if (count > maxCount) {
				maxCount = count;
				max = strings[i];
			}
			previous = strings[i];
		}
		for (int i = 0; i < maxCount; i++) {
			System.out.print(max + " ");
		}
		*/
		
		// Problem 04
		/*
		String[] strings = input.nextLine().split(" ");
		int previous = Integer.parseInt(strings[0]);
		int count = 1;
		int maxCount = 1;
		int[] current = new int[strings.length];
		current[0] = previous;
		int[] max = current;

		for (int i = 1; i < strings.length; i++) {
			int currentInt = Integer.parseInt(strings[i]);
			if (currentInt > previous) {
				count++;
			} else {
				System.out.print(current[0] + " ");
				for (int j = 1; j < current.length && current[j] > current[j - 1]; j++) {
					System.out.print(current[j] + " ");
				}
				System.out.println();
				count = 1;
				current = new int[strings.length];
			}
			current[count - 1] = currentInt;
			if (count > maxCount) {
				maxCount = count;
				max = current;
			}
			previous = currentInt;
		}
		System.out.print(current[0] + " ");
		for (int j = 1; j < current.length && current[j] > current[j - 1]; j++) {
			System.out.print(current[j] + " ");
		}
		System.out.println();
		System.out.print("Longest: ");
		System.out.print(max[0] + " ");
		for (int j = 1; j < max.length && max[j] > max[j - 1]; j++) {
			System.out.print(max[j] + " ");
		}
		*/
		
		// Problem 05
		/*
		String[] strings = input.nextLine().split("[^A-Za-z]+");
		System.out.println(strings.length);
		*/
		
		// Problem 06
		/*
		int count = 0;
		String[] strings = input.nextLine().split("[^A-Za-z]+");
		String word = input.nextLine();
		for (int i = 0; i < strings.length; i++) {
			if (strings[i].equalsIgnoreCase(word))
				count++;
		}
		System.out.println(count);
		*/
		
		// Problem 07
		/*
		String text = input.nextLine();
		String string = input.nextLine();
		int count = 0;
		for (int i = 0; i <= text.length() - string.length(); i++) {
			if (string.equalsIgnoreCase(text.substring(i, i + string.length())))
				count++;
		}
		System.out.println(count);
		*/
		
		// Problem 09
		/*
		ArrayList<Character> letters1 = new ArrayList<Character>();
		String[] chars = input.nextLine().split(" ");
		for (int i = 0; i < chars.length; i++) {
			letters1.add(chars[i].toCharArray()[0]);
		}
		ArrayList<Character> letters2 = new ArrayList<Character>();
		chars = input.nextLine().split(" ");
		for (int i = 0; i < chars.length; i++) {
			letters2.add(chars[i].toCharArray()[0]);
		}

		ArrayList<Character> letters = new ArrayList<Character>(letters1);
		Character letter = '\0';
		for (int i = 0; i < letters2.size(); i++) {
			letter = letters2.get(i);
			if (!letters1.contains(letter))
				letters.add(letter);
		}
		for (int i = 0; i < letters.size(); i++) {
			System.out.print(letters.get(i) + " ");
		}
		*/
		
		// Problem 10
		/*
		String[] text = input.nextLine().split("[^A-Za-z]+");
		ArrayList<String> unique = new ArrayList<String>();
		int index = 0;
		for (int i = 0; i < text.length; i++) {
			if (!unique.contains(text[i].toLowerCase()))
				unique.add(text[i].toLowerCase());
		}
		Collections.sort(unique);
		for (String word : unique) {
			System.out.print(word.toLowerCase() + " ");
		}
		*/
	}
}
