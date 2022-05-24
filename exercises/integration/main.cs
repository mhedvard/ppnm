using System; 
using static System.Math;
using static System.Console;
using System.IO;


class main{
	static void Main(){
		Func<double,double> f = delegate(double x){
			return Log(x)/Sqrt(x);
		};
		

		double a = 0; 
		double b = 1; 
		double r = integrate.quad(f,a,b); 


		WriteLine($"The result for int(ln(x)/sqrt(x))dx from 0 to 1: {r}.");
		WriteLine("The exact value is: -4");
	
		// Error function //
		StreamWriter erfdata = new StreamWriter("erf.dat");
		for(double x = -3; x<=3; x+=0.1){
			erfdata.WriteLine($"{x}	{erf(x)}"); 
		}
		erfdata.Close();
	}
	public static double erf(double z){
		Func<double, double> i = delegate(double x){
		return Exp(-x*x);
		};
		return 2/Sqrt(PI)*integrate.quad(i,0,z); 
	}
}
