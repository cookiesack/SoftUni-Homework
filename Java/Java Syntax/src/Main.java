import java.util.Scanner;
import java.util.Formatter;

public class Main {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		// Problem 01
		/* System.out.println(input.nextInt() * input.nextInt()); */

		// Problem 02
		/*
		 * int x1 = input.nextInt(); int y1 = input.nextInt(); int x2 =
		 * input.nextInt(); int y2 = input.nextInt(); int x3 = input.nextInt();
		 * int y3 = input.nextInt(); int area =
		 * Math.abs((x1*(y2-y3)+x2*(y3-y1)+x3*(y1-y2))/2); if(area<0) area=0;
		 * System.out.println(area);
		 */

		// Problem 03
		/*
		 * float x = input.nextFloat(); float y = input.nextFloat(); if (((x >=
		 * 12.5 && y >= 6) && (x <= 22.5 && y <= 13.5)) && (!((x > 17.5 && y >
		 * 8.5) && (x < 20 && y < 13.5)))) System.out.println("Inside"); else
		 * System.out.println("Outside");
		 */

		// Problem 04
		/*
		 * double a = input.nextDouble(); double b = input.nextDouble(); double
		 * c = input.nextDouble(); double min = a; if(b<min) min = b; if(c<min)
		 * min = c; System.out.println(min);
		 */

		// Problem 05
		/* System.out.println(Integer.toHexString(input.nextInt())); */

		// Problem 06
		/*
		 * int a = input.nextInt(); //float b = input.nextFloat(); //float c =
		 * input.nextFloat(); String str1 = String.format("%-10s",
		 * Integer.toHexString(a)); String str2 = String.format("%10'0'",
		 * Integer.toBinaryString(a)); String str3 = String.format("%10s",
		 * Integer.toBinaryString(a)); System.out.println("" + str2);
		 */

		// Problem 07
		/*
		 * int n = input.nextInt(); int bitCount = 0; String nBinary =
		 * Integer.toBinaryString(n); for (int i = 0; i < nBinary.length(); i++)
		 * { if (nBinary.toCharArray()[i] == '1') bitCount++; }
		 * System.out.println(bitCount);
		 */

		// Problem 08
		/*
		 * int n = input.nextInt(); int bitCount = 0; char previousBit; char[]
		 * nBinary = Integer.toBinaryString(n).toCharArray(); previousBit =
		 * nBinary[0]; for (int i = 1; i < nBinary.length; i++) { if (nBinary[i]
		 * == previousBit) bitCount++; else previousBit = nBinary[i]; }
		 * System.out.println(bitCount);
		 */

		// Problem 09
		/*
		 * float x = input.nextFloat(); float y = input.nextFloat(); if ((((17.5
		 * - 12.5) * (y - 8.5) - (3.5 - 8.5) * (x - 12.5) >= 0) && ((22.5 -
		 * 17.5) * (y - 3.5) - (8.5 - 3.5) * (x - 17.5) >= 0) && y <= 8.5) ||
		 * (((x >= 12.5 && y >= 8.5) && (x <= 22.5 && y <= 13.5)) && !(((x >
		 * 17.5 && y > 8.5) && (x < 20 && y < 13.5)))))
		 * System.out.println("Inside"); else System.out.println("Outside");
		 */
	}
}