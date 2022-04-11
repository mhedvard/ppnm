using System; 
using static System.Console; 
using static System.Math; 
using static linterp; 
// using vector;

class main{
	static void Main(){
		double[] x = {1,3,5,7,11,25,30}; 
		double[] y = {1,5,7,4,-5,-8,3};
		
		for(double xp = x[0]; xp <= x[x.Length-1]; xp+=0.01){
			WriteLine($"{xp}	{linterpPoint(x,y,xp)}	{linterpInteg(x,y,xp)}");
		}
	}

}
