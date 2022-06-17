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
		
		// Describtion of what is done to wtitten out in file
		WriteLine("The Akima subspline is used to interpolate the function sin(x) using the datapoints:");
		WriteLine(); 
		WriteLine("x	y");
		for(int i = 0; i<np; i++) 
			WriteLine($"{x[i]}	{y[i]}");
		WriteLine();
		WriteLine("From the interpolation the derivative and intergral (from 0 to x) is determind.");
		WriteLine("Remember that for the Akima-subsline the continuity of the second derevative is relaxed,");
		WriteLine("to reduce wiggeling. Therefor the first derivative is not necessarily a smooth curve.");


		// Akima subspline +  derevertive and integral 
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

