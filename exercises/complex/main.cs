using static System.Console;
using static System.Math;
using static cmath;

public class main{
	static void Main(){
		// Number used for test 
		complex mOne = new complex(-1);
		
		//Calculations 
		WriteLine($"sqrt(-1) = {sqrt(mOne)} (should be equal 0 + 1i)");
		WriteLine($"sqrt(i) = {sqrt(I)} (should be equal 0.707 + 0.707i)");
		WriteLine($"exp(i) = {exp(I)} (should be equal 0.540 + 0.841i)");
		WriteLine($"exp(i*pi) = {exp(I*PI)} (should be equal -1 + 0i)");
		WriteLine($"i^i = {cmath.pow(I,I)} (should be equal 0.208 + 0i)");
		WriteLine($"ln(i) = {log(I)} (should be equal 0 + 1.57i)");
		WriteLine($"sin(i*pi) = {sin(I*PI)} (should be equal 0 + 11.55i)");
		WriteLine($"sinh(i) = {sinh(I)} (should be equal 0 + 0.841i)");
		WriteLine($"cosh(i) = {cosh(I)} (should be equal 0.540 + 0i)");
	}
}
