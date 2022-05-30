using System; 
using static System.Console; 
using static System.Math;  
using static integrate;
using System.IO; 
 
class main{
	public static void Main(){
		int eval=0; 

		// Functions to test 
		Func<double, double> f1 = delegate(double x){
			eval ++; 
			return Sqrt(x);
		};

		Func<double, double> f2 = delegate(double x){
			eval ++; 
			return 1/Sqrt(x);
		};

		Func<double, double> f3 = delegate(double x){
			eval ++; 
			return 4*Sqrt(1-x*x);
		};

		Func<double, double> f4 = delegate(double x){
			eval ++; 
			return Log(x)/Sqrt(x);
		};
		
		// Test of integration methods	
		WriteLine($"Integral of sqrt(x) form 0 to 1 = {Integrate(f1,0,1)} (Should give 2/3), nuber of evalutions used: {eval}"); 
		eval = 0; 
		WriteLine($"ccIntegral of sqrt(x) form 0 to 1 = {ccIntegrate(f1,0,1)} (Should give 2/3), nuber of evalutions used: {eval}"); 
		eval = 0; 
		WriteLine();

		WriteLine($"Integral of 1/sqrt(x) form 0 to 1 = {Integrate(f2,0,1)} (Should give 2), nuber of evalutions used: {eval}"); 
		eval = 0; 
		WriteLine($"ccIntegral of 1/sqrt(x) form 0 to 1 = {ccIntegrate(f2,0,1)} (Should give 2), nuber of evalutions used: {eval}"); 
		eval = 0; 
		WriteLine();

		WriteLine($"Integral of 4*sqrt(1-x^2) form 0 to 1 = {Integrate(f3,0,1)} (Should give pi), nuber of evalutions used: {eval}"); 
		eval = 0; 
		WriteLine($"ccIntegral of 4*sqrt(1-x^2) form 0 to 1 = {ccIntegrate(f3,0,1)} (Should give pi), nuber of evalutions used: {eval}"); 
		eval = 0; 
		WriteLine();

		WriteLine($"Integral of ln(x)/sqrt(x) form 0 to 1 = {Integrate(f4,0,1)} (Should give 2/3), nuber of evalutions used: {eval}"); 
		eval = 0; 
		WriteLine($"ccIntegral of ln(x)/sqrt(x) form 0 to 1 = {ccIntegrate(f4,0,1)} (Should give 2/3), nuber of evalutions used: {eval}"); 
		eval = 0; 
		WriteLine();

	}
}
