using System; 
using static System.Console; 
using static System.Math;  
using static integrate;
using System.IO; 
 
class main{
	public static void Main(){
		// Test integrator function
		Func<double, double> f1 = x => Sqrt(x), f2 = x => 1/Sqrt(x), f3 = x => 4*Sqrt(1-x*x), f4 = x => Log(x)/Sqrt(x); 
		WriteLine($"Integral of sqrt(x) form 0 to 1 = {Integrate(f1,0,1)} (Should give 2/3)"); 
		WriteLine($"Integral of 1/sqrt(x) form 0 to 1 = {Integrate(f2,0,1)} (Should give 2)"); 
		WriteLine($"Integral of 4*sqrt(1-x^2) form 0 to 1 = {Integrate(f3,0,1)} (Should give pi)");	
		WriteLine($"Integral of ln(x)/sqrt(x) form 0 to 1 = {Integrate(f4,0,1)} (Should give -4)"); 
		
		//Test of error function
		StreamWriter erfVal = new StreamWriter("erf.dat"); 
		for(double z =-3; z<=3; z+=0.1)
			erfVal.WriteLine($"{z}	{erf(z)}"); 
		erfVal.Close(); 

	}

	// Error function
	public static double erf(double z){
		Func <double, double> f = x => 2/Sqrt(PI)*Exp(-x*x);
		return Integrate(f, 0, z); 
	}
}
