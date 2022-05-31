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
		WriteLine("Test of sin(x)*cos(y)"); 
		WriteLine();		
		vector a = new vector(-PI,-PI); 
		vector b = -a;

		int N1 = 10;
		(double t1, double err1) = plainmc(f, a, b, N1);
		WriteLine($"The integral sin(x)*sin(y) from (-pi,-pi) to (pi,pi) = {t1} (expexted to be 0)");
		WriteLine($"The number of point used N = {N1}");
		WriteLine($"The error estimate error = {err1}");
		WriteLine($""); 

		WriteLine("Increase the number of points");
		int N2 = 1000;
		(double t2, double err2) = plainmc(f, a, b, N2);
		WriteLine($"The integral sin(x)*sin(y) from (-pi,-pi) to (pi,pi) = {t2} (expexted to be 0)");
		WriteLine($"The number of point used N = {N2}");
		WriteLine($"The error estimate error = {err2}");
		WriteLine($""); 

		WriteLine("Increase the number of points");
		int N3 = 100000; 
		(double t3, double err3) = plainmc(f, a, b, N3);
		WriteLine($"The integral sin(x)*sin(y) from (-pi,-pi) to (pi,pi) = {t3} (expexted to be 0)");
		WriteLine($"The number of point used N = {N3}");
		WriteLine($"The error estimate error = {err3}");
		WriteLine($""); 
		WriteLine();

		WriteLine("---------------------------------------------");
		WriteLine("");
		WriteLine("Test of 1/(pi^3*[1-cos(x)cos(y)cos(z)])"); 
		vector c = new vector(0,0,0); 
		vector d = new vector(PI,PI,PI);

		int N = 1000000;
		(double t, double err) = plainmc(g, c, d, N);
		WriteLine($"The integral 1/(pi^3*[1-cos(x)cos(y)cos(z)]) from (0,0,0) to (pi,pi,pi) = {t} (expexted to be 1.3932)");
		WriteLine($"The number of point used N = {N}");
		WriteLine($"The error estimate error = {err}");
		WriteLine($"");


	}
} 
