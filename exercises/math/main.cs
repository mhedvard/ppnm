
using static System.Console;
using static System.Math;

class math{
	static void Main(){
		double sqrt2=Sqrt(2.0); 
		Write($"sqrt(2) = {sqrt2}\n");
		Write($"sqrt(2)*sqrt(2) = {sqrt2*sqrt2} (should be equal 2)\n");
		WriteLine(""); 

		double epi=Exp(PI); 
		Write($"e^pi = {epi}\n");
		Write($"ln(e^pi) = {Log(epi)} (should be equal pi)\n");
		WriteLine("");

		double pie=Pow(PI,E); 
		Write($"pi^e = {pie}\n");
		Write($"ln(pi^e)/ln(pi) = {Log(pie)/Log(PI)} (should be equal e={E})\n");
		WriteLine("");
	}
}
