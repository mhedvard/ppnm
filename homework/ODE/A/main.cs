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

		
		// Test of routines //		
		WriteLine("Test of routines by solving u''=u from 0 to 1 where u0=[1,1]");		
		double a = 0, b = 1; 
		vector ya = new vector(1,1);				
		vector sol = driver.driver12(f, a, b, ya); 
		sol.print();
		WriteLine("Result from matlab using ode45: 1.3818, -0.3012"); 
		WriteLine("Test OK");  
		WriteLine(""); 

		//////////////////////////////
		// Oscillator with friction //
		//////////////////////////////

		double t0 = 0, step = 0.1; 
		int imax = 101; 
		vector y0 = new vector(PI-0.1,0);				

		vector solStep; 

		StreamWriter PendRes = new StreamWriter("PendRes.dat"); 
		PendRes.WriteLine($" {t0} {y0[0]} {y0[1]}"); 
		
		for(int i = 1; i < imax; i ++){
			solStep = driver.driver12(pend, t0, t0+step, y0);
			y0 = solStep; 
			t0 += step;
		
			PendRes.WriteLine($" {t0} {y0[0]} {y0[1]}"); 
		}
		PendRes.Close();		
 
	}
}
