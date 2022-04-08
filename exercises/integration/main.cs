using static System.Math;
using static System.Console;
using System;
using static integrate;

class main{
	static void Main(){
		System.Func<double,double> f = delegate(double x){
			return Log(x)/Sqrt(x);
		};

		double a = 0; 
		double b = 1; 
		double r = integrate.quad(f,a,b); 


		WriteLine($"The result for int(ln(x)/sqrt(x))dx from 0 to 1: {r}.");
		WriteLine("The exact value is: -4");
	}
}
