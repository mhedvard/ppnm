using System; 
using static System.Console; 
using static System.Math; 


class main{
	static void Main(){
		double[] x = {0,1,2,3,4,5}; 
		double[] y = {-1,-1,-1,1,1,1};
		
		var subs = new akima(x,y);	
		var cs = new cspline(x,y); 

		for(int i = 0; i < x.Length; i++)
			WriteLine($"{x[i]}	{y[i]}"); 
		WriteLine("");
		WriteLine("");		

		for(double xp = x[0]; xp < x[x.Length-1]; xp+=0.1){
			WriteLine($"{xp}	{subs.getS(xp)}");
		}
		WriteLine("");
		WriteLine("");		

		for(double xp = x[0]; xp < x[x.Length-1]; xp+=0.1){
			WriteLine($"{xp}	{cs.spline(xp)}");
		}
	}

}
