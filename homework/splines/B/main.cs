using System; 
using static System.Console; 
using static System.Math; 

class main{
	static void Main(){
		double[] x = {0,1,2,3,4,5,6}; 
		double[] y = {0,1,2,0,-2,-1,0};

		for(int i = 0; i < x.Length; i++)
			WriteLine($"{x[i]}	{y[i]}"); 
		WriteLine("");
		WriteLine("");

		var qs = new qspline(x,y);
		for(double z = x[0]; z<= x[x.Length-1]; z+=0.1)
			WriteLine($" {z}	{qs.spline(z)}");
		/*
		for(int i = 0; i < x.Length; i++)
			WriteLine($"{x[i]}	{y[i]}"); 
		WriteLine("");
		WriteLine("");		

		for(double xp = x[0]; xp <= x[x.Length-1]; xp+=0.01){
			WriteLine($"{xp}	{linterpPoint(x,y,xp)}	{linterpInteg(x,y,xp)}");
		}*/
	}

}
