using System;
using static System.Console;
using static System.Math;
using static vec;

class main{
	static void Main(){
		// Vectors and constant used for test
		vec vecA =new vec(1, 2, 3);
		vec vecB =new vec(4, 5, 6);
		
		WriteLine("Vectors and constants used for tests");
		vecA.print("vecA =");
		vecB.print("vecB =");
		WriteLine(" ");

		// Test of methods (part B)
		
		WriteLine("Test of methodes (part B)");

		double dotAB = dot(vecA,vecB);
		WriteLine($"The dot product of vecA*vecB = {dotAB} (should be equal 32)");

		vec crossAB = cross(vecA, vecB);
		crossAB.print("The cross product of vecA x vecB","(should be equal -3 6 -3)");

		double normA = norm(vecA);
		WriteLine($"The norm of vecA = {normA} (should be equal 3.7417)");
		
		WriteLine($"Test of ToString on vecA: {vecA.ToString()} (should be equal 1 2 3)");
	}
}
