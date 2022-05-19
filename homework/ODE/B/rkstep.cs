using System; 
using static System.Console;
using static System.Math;

public class rkstep{
	public static (vector, vector) rkstep12( Func<double,vector,vector> f, double x0, vector y0, double h){
	/* 
	f is the function to solve
	x0 is the current position
	y0 is the current value y0(x0)
	h is the step size
	*/	
	
	// calculate the value of k
	vector k0 = f(x0,y0); 
	vector k = f(x0+0.5*h,y0+0.5*h*k0);
	
	// Calculate solution
	vector y = y0+h*k; 
	// Calculate error estimate
	vector erv = (k - k0) * h; 
	return (y,erv); 
	}
}
