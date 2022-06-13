using System; 
using static System.Console; 
using static System.Math; 
//using akima; 

class main{
	static void Main(){
		double[] x = {0,1,2,3,4,5,6}; 
		double[] y = {0,1,1,0.5,-1,-1,0};
		
		var subs = new akima(x,y);		

		for(int i = 0; i < x.Length; i++)
			WriteLine($"{x[i]}	{y[i]}"); 
		WriteLine("");
		WriteLine("");		

		for(double xp = x[0]; xp < x[x.Length-1]; xp+=0.1){
			WriteLine($"{xp}	{subs.getS(xp)}");
		}
	}

}
