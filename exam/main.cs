using System; 
using static System.Console; 
using static System.Math; 
using System.IO; 

class main{
	static void Main(){
		// Compare wiggles for cubic spline and Akima 
		double[] x = {0,1,2,3,4,5,6,7,8,9,10}; 
		double[] y = {-1,-1,-1,1,1,1,1,1,0,0,0};
		
		var subsWiggle = new akima(x,y);	
		var csWiggle = new cspline(x,y); 
		
		StreamWriter smWiggle = new StreamWriter("testWiggle.dat"); 
		for(int i = 0; i < x.Length; i++)
			smWiggle.WriteLine($"{x[i]}	{y[i]}"); 
		smWiggle.WriteLine("");
		smWiggle.WriteLine("");		

		for(double xp = x[0]; xp < x[x.Length-1]; xp+=0.1){
			smWiggle.WriteLine($"{xp}	{subsWiggle.getS(xp)}");
		}
		smWiggle.WriteLine("");
		smWiggle.WriteLine("");		

		for(double xp = x[0]; xp < x[x.Length-1]; xp+=0.1){
			smWiggle.WriteLine($"{xp}	{csWiggle.spline(xp)}");
		}
		smWiggle.Close(); 
	}

}
