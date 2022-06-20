using System; 
using static System.Console; 
using static System.Math; 
using System.IO; 

class main{
	static void Main(){
		////////////////////////////////////////////////////
		// Test for wiggles for cubic spline and Akima //
		////////////////////////////////////////////////////
		double[] x = {-5,-4,-3,-2,-1,1,2,3,4,5}; 
		double[] y = {-1,-1,-1,-1,-1,1,1,1,1,1};
		int np = x.Length;
		// Describtion of what is done to wtitten out in file
		WriteLine("The Akima subspline and the cubic spline is used to interpolate the datapoints:");
		WriteLine(); 
		WriteLine("x	y");
		for(int i = 0; i<np; i++) 
			WriteLine($"{x[i]}	{y[i]}");

		// Akima subspline +  derevertive and integral 
		var subs = new akima(x,y); 
		var cs = new cspline(x,y); 

		StreamWriter sw = new StreamWriter("Wiggles.dat"); 
		for(int i = 0; i < x.Length; i++)
			sw.WriteLine($"{x[i]}	{y[i]}"); 
		sw.WriteLine("");
		sw.WriteLine("");		

		for(double xp = x[0]; xp < x[x.Length-1]; xp+=0.1){
			sw.WriteLine($"{xp}	{subs.getS(xp)}	{cs.spline(xp)}");
		}
		sw.Close(); 
	}

}
