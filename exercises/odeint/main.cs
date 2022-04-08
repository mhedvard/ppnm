using System; 
using static System.Console; 
using static System.Math; 
using System.Collections;
using System.Collections.Generic;

class main{
	static void Main(){
		double b = 0.25; 
		double c = 5.0; 
		vector y0 = new vector(PI - 0.1, 0.0); 

		Func<double, vector, vector> f = delegate(double t, vector y){
			double theta = y[0];
			double omega =y[1]; 
			vector dydt = new vector(omega, - b * omega - c * Sin(theta));  
			return dydt; 
		};

		double t0 = 0, tend = 10; 

		var xlist = new List<double>(); 
		var ylist = new List<vector>(); 
		vector yend = ode.ivp(f, t0, y0, tend, xlist, ylist); 
		
		for(int i = 0; i < xlist.Count; i++)
			WriteLine($"{xlist[i]}	{ylist[i][0]}	{ylist[i][0]}");
		
	}

}
