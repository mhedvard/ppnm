using System;
using static System.Console;
using static System.Math;
using static vec;

class main{
	static void Main(){
		// Vectors and constant used for test
		vec vecA =new vec(1, 2, 3);
		vec vecB =new vec(4, 5, 6);
		double a = 2.0;
		
		WriteLine("Vectors and constants used for tests");
		vecA.print("vecA =");
		vecB.print("vecB =");
		WriteLine($"a = {a}");
		WriteLine("");

		// Test of operatores
		WriteLine("Test of operators part A");
		var vecC  = a*vecA;
		(vecC).print("a*VecA = ","(should be equal 2 4 6)");
		
		(vecA+vecB).print("VecA + VecB = ","(should be equal 5 7 9)");
		(vecA-vecB).print("VecA - VecB = ","(should be equal -3 -3 -3)");
		(-vecA).print("-VecA = ","(should be equal -1 -2 -3)");
		
	}
}
