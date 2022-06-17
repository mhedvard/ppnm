using System; 
using static System.Console; 
using static System.Math; 
using System.IO; 

class main{
	static void Main(){
		double[] x = {0,0.5,1,1.5,2,2.5,3,3.5,4,4.5,5};
		double[] y = new double[x.Length];
		for(int i = 0; i < x.Length; i++)
			y[i] = Sin(x[i]);
		
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

