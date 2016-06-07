import java.util.Scanner;
import java.util.Random;
import java.io.*;
import java.util.Date;
import java.text.SimpleDateFormat;

public class Main {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		// Problem 01
/*
		int start = input.nextInt();
		int end = input.nextInt();
		for (int i = start; i <= end; i++) {
			if (i < 10 || i % 10 == i / 100 || i % 10 == i / 10)
				System.out.print(i + " ");
		}
*/
		
		// Problem 02
/*
		char[] characters = input.next().toCharArray();
		for (int i = 0; i < characters.length; i++) {
			for (int j = 0; j < characters.length; j++) {
				for (int k = 0; k < characters.length; k++) {
					System.out.print("" + characters[i] + characters[j] + characters[k] + " ");
				}
			}
		}
*/
		
		// Problem 03
/*
		int count = 0;
		String card1 = "";
		String card2 = "";
		for (int i = 2; i < 15; i++) {
			for (int j = 2; j < 15; j++) {
				if (j != i) {
					if (i < 11)
						card1 = "" + i;
					else {
						switch (i) {
						case 11:
							card1 = "J";
							break;
						case 12:
							card1 = "Q";
							break;
						case 13:
							card1 = "K";
							break;
						case 14:
							card1 = "A";
							break;
						}
					}
					if (j < 11)
						card2 = "" + j;
					else {
						switch (j) {
						case 11:
							card2 = "J";
							break;
						case 12:
							card2 = "Q";
							break;
						case 13:
							card2 = "K";
							break;
						case 14:
							card2 = "A";
							break;
						}
					}

					PrintCombinations(card1, card2);
					count += 24;
				}
			}
		}
		System.out.println(count + " full houses");
*/
		
		// Problem 05
/*
		int count = input.nextInt();
		input.nextLine();
		for (int i = 0; i < count; i++) {
			System.out.printf("%.6f", ConvertDegRad(input.nextLine().split(" ")));
		}
*/
		
		// Problem 06
/*
		Random rand = new Random();
		int cardNum = 0;
		String card = "";
		int signNum = 0;
		String sign = "";
		int count = input.nextInt();
		for (int j = 0; j < count; j++) {
			for (int i = 0; i < 5; i++) {
				cardNum = rand.nextInt(13) + 2;
				signNum = rand.nextInt(4);
				switch (cardNum) {
				case 11:
					card = "J";
					break;
				case 12:
					card = "Q";
					break;
				case 13:
					card = "K";
					break;
				case 14:
					card = "A";
					break;
				default:
					card = Integer.toString(cardNum);
				}
				switch (signNum) {
				case 0:
					sign = "\u2660";
					break;
				case 1:
					sign = "\u2663";
					break;
				case 2:
					sign = "\u2665";
					break;
				case 3:
					sign = "\u2666";
					break;
				}

				System.out.print("" + card + sign + " ");
			}
			System.out.println();
		}
*/
		
		// Problem 08
/*
		int sum = 0;
		try (BufferedReader br = new BufferedReader(new FileReader("input.txt"))) {
			String line;
			while ((line = br.readLine()) != null) {
				sum += Integer.parseInt(line);
			}
		} catch (Exception e) {
			System.out.println("Error");
		}
		System.out.println(sum);
*/
	}

	private static void PrintCombinations(String card1, String card2) {
		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2663' + card1 + '\u2665' + card2 + '\u2660' + card2 + '\u2661');
		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2663' + card1 + '\u2665' + card2 + '\u2660' + card2 + '\u2665');
		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2663' + card1 + '\u2665' + card2 + '\u2660' + card2 + '\u2666');
		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2663' + card1 + '\u2665' + card2 + '\u2663' + card2 + '\u2665');
		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2663' + card1 + '\u2665' + card2 + '\u2663' + card2 + '\u2666');
		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2663' + card1 + '\u2665' + card2 + '\u2665' + card2 + '\u2666');

		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2663' + card1 + '\u2666' + card2 + '\u2660' + card2 + '\u2661');
		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2663' + card1 + '\u2666' + card2 + '\u2660' + card2 + '\u2665');
		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2663' + card1 + '\u2666' + card2 + '\u2660' + card2 + '\u2666');
		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2663' + card1 + '\u2666' + card2 + '\u2663' + card2 + '\u2665');
		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2663' + card1 + '\u2666' + card2 + '\u2663' + card2 + '\u2666');
		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2663' + card1 + '\u2666' + card2 + '\u2665' + card2 + '\u2666');

		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2665' + card1 + '\u2666' + card2 + '\u2660' + card2 + '\u2661');
		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2665' + card1 + '\u2666' + card2 + '\u2660' + card2 + '\u2665');
		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2665' + card1 + '\u2666' + card2 + '\u2660' + card2 + '\u2666');
		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2665' + card1 + '\u2666' + card2 + '\u2663' + card2 + '\u2665');
		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2665' + card1 + '\u2666' + card2 + '\u2663' + card2 + '\u2666');
		System.out.println(
				"" + card1 + '\u2660' + card1 + '\u2665' + card1 + '\u2666' + card2 + '\u2665' + card2 + '\u2666');

		System.out.println(
				"" + card1 + '\u2663' + card1 + '\u2665' + card1 + '\u2666' + card2 + '\u2660' + card2 + '\u2661');
		System.out.println(
				"" + card1 + '\u2663' + card1 + '\u2665' + card1 + '\u2666' + card2 + '\u2660' + card2 + '\u2665');
		System.out.println(
				"" + card1 + '\u2663' + card1 + '\u2665' + card1 + '\u2666' + card2 + '\u2660' + card2 + '\u2666');
		System.out.println(
				"" + card1 + '\u2663' + card1 + '\u2665' + card1 + '\u2666' + card2 + '\u2663' + card2 + '\u2665');
		System.out.println(
				"" + card1 + '\u2663' + card1 + '\u2665' + card1 + '\u2666' + card2 + '\u2663' + card2 + '\u2666');
		System.out.println(
				"" + card1 + '\u2663' + card1 + '\u2665' + card1 + '\u2666' + card2 + '\u2665' + card2 + '\u2666');
	}

	private static double ConvertDegRad(String[] params) {
		if (params[1].equals("deg"))
			return Double.parseDouble(params[0]) / 57.2957795;
		else if (params[1].equals("rad"))
			return Double.parseDouble(params[0]) * 57.2957795;
		else
			return -1;
	}
}