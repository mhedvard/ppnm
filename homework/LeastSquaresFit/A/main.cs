using System; 
using static System.Console; 
using static System.Math; 

class main{
	static void Main(){
		// Data
		var t = new vector(new double[] {1,  2,  3, 4, 6, 9,   10,  13,  15});
		var y = new vector(new double[] {117,100,88,72,53,29.5,25.2,15.2,11.1}); 
		var dy = new vector(new double[] {5,5,5,5,5,5,1,1,1,1});
		
		//Function 
		var fs = new Func<double,double>[]{x => 1.0, x => -x};
		
		vector lny = new vector(y.size);
		vector dlny = new vector(dy.size);
		// Change to work with ln(y) = ln(a)+lambda*t
		for(int i=0; i<y.size; i++){
			lny[i] = Log(y[i]);
			dlny[i] = dy[i]/y[i]; 
		}
	
		// Solve problem	
		var ls = new lsfit(fs, t, lny,  dlny);
		var c = ls.c;
	
		double a = Exp(ls.c[0]);
		double lambda = c[1];

		// Write data to file
		for(int i=0; i<t.size; i++){
			WriteLine($"{t[i]}	{y[i]}	{dy[i]}");
		}

		WriteLine("");
		WriteLine("");

		for(double time=t[0]; time <= t[t.size-1]; time+=0.1){
			WriteLine($"{time}	{a*Exp(-lambda*time)}");
		}
		
	}
}
