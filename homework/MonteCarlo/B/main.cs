using System; 
using static System.Console; 
using static System.Math;
using static mcint; 

class main{
	static void Main(){
		// Function for test 
		Func<vector, double> f = delegate(vector x){
			return Sin(x[0])*Cos(x[1]);
		};

		Func<vector, double> g = delegate(vector x){
			return 1/(Pow(PI,3)*(1-Cos(x[0])*Cos(x[1])*Cos(x[2])));
		}; 

		// Test of sin(x),cos(y)
		WriteLine($"The integral sin(x)*sin(y) from (-pi,-pi) to (pi,pi) (expexted to be 0)");
		WriteLine();		
		vector a = new vector(-PI,-PI); 
		vector b = -a;
		
		for(int N = 10; N <= 1000000; N*=10){
			WriteLine($"The number of point used N = {N}");
			WriteLine($"Using plain montecarlo: {plainmc(f, a, b, N)} (result, error)");
			WriteLine($"Using plain montecarlo: {corputmc(f, a, b, N)} (result, error)"); 
			WriteLine($"");
		}


		WriteLine("----------------------------------------------------------");
		vector c = new vector(0,0,0); 
		vector d = new vector(PI,PI,PI);

		WriteLine($"The integral 1/(pi^3*[1-cos(x)cos(y)cos(z)]) from (0,0,0) to (pi,pi,pi) (expexted to be 1.3932)");
		WriteLine(); 

		for(int N = 10; N <= 1000000; N*=10){
			WriteLine($"The number of point used N = {N}");
			WriteLine($"Using plain montecarlo: {plainmc(g, c, d, N)} (result, error)");
			WriteLine($"Using plain montecarlo: {corputmc(g, c, d, N)} (result, error)"); 
			WriteLine($"");  
		}
		
	}
} 
