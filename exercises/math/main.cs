
using static System.Console;
using static System.Math;

class math{
	static void Main(){
		double sqrt2=Sqrt(2.0); 
		Write($"sqrt(2) = {sqrt2}\n");
		Write($"sqrt2*sqrt2 = {sqrt2*sqrt2} (should be equal 2)\n");

		double epi=Exp(PI); 
		Write($"e^pi = {epi}\n");
		Write($"ln(e^pi) = {Log(epi)} (should be equal pi)\n");

		double pie=Pow(PI,E); 
		Write($"pi^e = {pie}\n");
	}
}
