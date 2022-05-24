using System; 
using static System.Console; 
using static System.Math; 

class main{
	static void Main(){
		var x = new double[8]; 
		var y = new double[8];

		for(int i = 0; i < x.Length; i++){
			x[i] = i;
			y[i] = Sin(x[i]);	
			WriteLine($"{x[i]}	{y[i]}");
		} 
		WriteLine("");
		WriteLine("");

		calspline(x,y);
	}

	static void calspline(double[] x,double[] y){
		var cs = new cspline(x,y);
		for(double z = x[0]; z<= x[x.Length-1]; z+=0.1)
			WriteLine($" {z}	{cs.spline(z)}	{cs.derivative(z)}	{cs.integral(z)}"	);
		WriteLine("");
		WriteLine("");
	}

}
