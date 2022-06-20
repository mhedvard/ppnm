using System; 
using static System.Console; 
using static System.Math; 
using System.IO; 

class main{
	static void Main(){
		////////////////////////////////////////////////////////////////
		// Rounge's phenomenom for polynomial interpolation and Akima //
		////////////////////////////////////////////////////////////////
		double[] x = {-5,-4,-3,-2,-1,1,2,3,4,5};
		int np = x.Length; 
		double[] y = new double[np];

		for(int i = 0; i < x.Length; i++){
			y[i] = 1/(1+25*x[i]*x[i]);
		}


		// Describtion of what is done to output file 
		WriteLine("Investergation of Rounge's phenomenom for polynomial interpolation and Akima sub-spline.");
		WriteLine("The test is made on the function 1/(1+25*x^2). The data point used:");
		WriteLine(); 
		WriteLine("x	y");
		for(int i = 0; i<np; i++) 
			WriteLine($"{x[i]}	{y[i]}");
		WriteLine();

		// Make interpolation
		var subs = new akima(x,y); 
		
		var sw = new StreamWriter("RungesPhen.dat"); 
		for(int i = 0; i < x.Length; i++)
			sw.WriteLine($"{x[i]}	{y[i]}"); 
		sw.WriteLine("");
		sw.WriteLine("");		

		for(double xp = x[0]; xp < x[x.Length-1]; xp+=0.01){
			sw.WriteLine($"{xp}	{subs.getS(xp)}	{polyInt.P(x,y,xp)}");
		}
		sw.Close(); 
	}

}
