using System;
using static System.Console;
using static System.Math;
using static vec;

class main{
	static void Main(){
		// Vectors and constant used for test
		vec vecA =new vec(1.0, 2.0, 3.0);
		vec vecB =new vec(1.1, 2.2, 3.3);
		vec vecC =new vec(1.0, 2.0, 3.3);		

		WriteLine("Vectors and constants used for tests");
		vecA.print("vecA =");
		vecB.print("vecB =");
		vecC.print("vecC =");			

		WriteLine(" ");

		// Test of methods (part C)
		
		WriteLine("Test of methodes (part C)");

		WriteLine($"Approx of vecA,vecA: {approx(vecA,vecA)} (should be True)");
		WriteLine($"Approx of vecA,vecB: {approx(vecA,vecB)} (should be False)");
		WriteLine($"Approx of vecA,vecC: {vecA.approx(vecC)} (should be False)");

	}
}
