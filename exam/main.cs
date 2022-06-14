using System; 
using static System.Console; 
using static System.Math; 
using System.IO; 

class main{
	static void Main(){
		////////////////////////////////////////////////
		// Compare wiggles for cubic spline and Akima //
		////////////////////////////////////////////////
		double[] x = {0,1,2,3,4,5,6,7,8,9,10}; 
		double[] y = {-1,-1,-1,1,1,1,1,1,0,0,0};
		
		var subs = new akima(x,y);	
		var cs = new cspline(x,y); 
		
		StreamWriter sw = new StreamWriter("testWiggle.dat"); 
		for(int i = 0; i < x.Length; i++)
			sw.WriteLine($"{x[i]}	{y[i]}"); 
		sw.WriteLine("");
		sw.WriteLine("");		

		for(double xp = x[0]; xp < x[x.Length-1]; xp+=0.1){
			sw.WriteLine($"{xp}	{subs.getS(xp)}");
		}
		sw.WriteLine("");
		sw.WriteLine("");		

		for(double xp = x[0]; xp < x[x.Length-1]; xp+=0.1){
			sw.WriteLine($"{xp}	{cs.spline(xp)}");
		}
		sw.Close(); 



		////////////////////////////////////////////////////
		// Rounge's phenomenom for cubic spline and Akima //
		////////////////////////////////////////////////////
		double[] x = {-5,-4,-3,-2,-1,1,2,3,4,5}; 
		double[] y = new double[x.Length];

		for(int i = 0; i < x.length; i++){
			y[i] = 1/(1+25*x[i]*x[i]);
		}
		
		var subs = new akima(x,y);	
		var cs = new cspline(x,y); 
		
		var sw = new StreamWriter("testRungesPhen.dat"); 
		for(int i = 0; i < x.Length; i++)
			sw.WriteLine($"{x[i]}	{y[i]}"); 
		sw.WriteLine("");
		sw.WriteLine("");		

		for(double xp = x[0]; xp < x[x.Length-1]; xp+=0.1){
			sw.WriteLine($"{xp}	{subs.getS(xp)}");
		}
		sw.WriteLine("");
		sw.WriteLine("");		

		for(double xp = x[0]; xp < x[x.Length-1]; xp+=0.1){
			sw.WriteLine($"{xp}	{cs.spline(xp)}");
		}
		sw.Close(); 
	}

}
