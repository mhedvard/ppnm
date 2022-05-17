using System; 
using static System.Console;
using static System.Math;

public class driver{
	public static vector driver12(Func<double, vector, vector> f, double a, double b, vector ya, double h0 = 0.01, double acc = 0.01, double eps = 0.01){
	/*
	f is the fuction to solve 
	a is the start point 
	b is the end point
	ya is the solution to y(a)
	h0 is the initial step size
	acc is the absolut accuracy goal
	eps is the relative accuracy goal
	*/
		vector yi, erv;
		double err, tol; 
		double x = a;   
		vector y = ya; 
		double h = h0;

		if(a>b) 
			throw new Exception("driver: a>b");

		while(x < b){
			if(x+h > b) h = b-x;  
			(yi, erv) = rkstep.rkstep12(f, x, y, h);
			err = erv.norm();
			tol = Max(acc,yi.norm()*eps)*Sqrt(h/(b-a));
			if(err<= tol){
				y = yi; 
				x += h;	
			}
			h *=Min(Pow(tol/err,0.25)*0.95,2); 
		}
		return y;  
	}		
}

 
