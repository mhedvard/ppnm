using System; 
using static System.Console; 
using static System.Math; 
using System.IO;

class main{
	static void Main(){
		Func<double, vector, vector> f = delegate(double t, vector y){
			double theta = y[0];
			double omega = y[1]; 
			return new vector(omega, -theta);
		};

		
		Func<double, vector, vector> pend = delegate(double t, vector y){
			double bp = 0.25, cp = 5.0;
			double theta = y[0];
			double omega = y[1]; 
			return new vector(omega, -bp*omega-cp*Sin(theta));
		};
		
		
		// Test of routine //		
		WriteLine("Test of routines by solving u''=u from 0 to 1 where u0=[1,1]");		
		double a = 0, b = 1; 
		vector ya = new vector(1,1);	
		genlist<double> xi = new genlist<double>(); 
		genlist<vector> yi = new genlist<vector>(); 
					
		vector yb = driver.driver12(f, a, b, ya, xi, yi);
		yb.print();
		WriteLine("Result from matlab using ode45: 1.3818, -0.3012"); 
		WriteLine("Test OK");  
		WriteLine("");
		WriteLine("Results for steps:");  
		WriteLine("xi	yi	yi'");
		for(int i = 0; i < xi.size ;i++)
			WriteLine($" {xi.data[i]}	{yi.data[i][0]}	{yi.data[i][1]}");		
				
		
		//////////////////////////////
		// Oscillator with friction //
		//////////////////////////////

		double t0 = 0, tf = 10; 
		vector u0 = new vector(PI-0.1,0);				
		
		genlist<double> ti = new genlist<double>(); 
		genlist<vector> ui = new genlist<vector>(); 

		driver.driver12(pend, t0, tf, u0, ti, ui, 0.1);

		StreamWriter PendRes = new StreamWriter("PendRes.dat"); 
		for(int i = 0; i < ti.size ;i++)
			PendRes.WriteLine($" {ti.data[i]}	{ui.data[i][0]}	{ui.data[i][1]}");		
		PendRes.Close();
				
	}
}
