using System; 
using static System.Console; 
using static System.Math; 

class main{
	static void Main(){
		var x = new double[5]; 
		var y = new double[5];

		for(int i = 0; i < x.Length; i++){
			x[i] = i;
			y[i] = 1;	
			WriteLine($"{x[i]}	{y[i]}");
		} 
		WriteLine("");
		WriteLine("");

		calspline(x,y);

		for(int i = 0; i < x.Length; i++){
			x[i] = i;
			y[i] = x[i];	
			WriteLine($"{x[i]}	{y[i]}");
		} 
		WriteLine("");
		WriteLine("");

		calspline(x,y);

		for(int i = 0; i < x.Length; i++){
			x[i] = i;
			y[i] = Pow(x[i],2);	
			WriteLine($"{x[i]}	{y[i]}");
		} 
		WriteLine("");
		WriteLine("");

		calspline(x,y);

	}

	static void calspline(double[] x,double[] y){
		var qs = new qspline(x,y);
		for(double z = x[0]; z<= x[x.Length-1]; z+=0.1)
			WriteLine($" {z}	{qs.spline(z)}	{qs.derivative(z)}	{qs.integral(z)}"	);
		WriteLine("");
		WriteLine("");
	}

}
