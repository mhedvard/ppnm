using System; 
using static System.Console; 
using static System.Math; 
using System.IO; 

class main{
	static void Main(){
		// Data points 
		int np = 20;
		double[] x = new double[np];
		double[] y = new double[np];
		for(int i = 0; i < np; i++){
			x[i] = i*0.5;
			y[i] = Sin(x[i]);
		}
		
		// Describtion of what is done, wtitten in output file
		WriteLine("The Akima sub-spline is used to interpolate the function sin(x) using the data points:");
		WriteLine(); 
		WriteLine("x	y");
		for(int i = 0; i<np; i++) 
			WriteLine($"{x[i]}	{y[i]}");
		WriteLine();
		WriteLine("From the Akima sub-spline method the derivative and integral (from 0 to x) is also determined. ");
		WriteLine("Remember that for the Akima sub-spline the continuity of the second derivative is relaxed, to reduce wiggling. ");
		WriteLine("Therefore, the first derivative is not necessarily a smooth curve.");


		// Akima subspline + derevertive and integral 
		var subs = new akima(x,y); 
		
		StreamWriter sw = new StreamWriter("testAkima.dat"); 
		for(int i = 0; i < x.Length; i++)
			sw.WriteLine($"{x[i]}	{y[i]}"); 
		sw.WriteLine("");
		sw.WriteLine("");		

		for(double xp = x[0]; xp < x[x.Length-1]; xp+=0.1){
			sw.WriteLine($"{xp}	{subs.getS(xp)}	{subs.derivative(xp)}	{subs.integral(xp)}");
		}
		sw.Close(); 
	}
}

