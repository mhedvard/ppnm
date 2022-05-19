using System; 
using static System.Console;
using static System.Math;

public class driver{
	public static vector driver12(Func<double, vector, vector> f, double a, double b, vector ya, genlist<double> xlist = null, genlist<vector> ylist = null , double h0 = 0.01, double acc = 0.01, double eps = 0.01){
	/*
	f is the fuction to solve 
	a is the start point 
	b is the end point
	ya is the solution to y(a)
	h0 is the initial step size
	acc is the absolut accuracy goal
	eps is the relative accuracy goal
	*/	
		vector yh, erv;
		double ratioMin; 
		double x = a;   
		vector y = ya; 
		double h = h0;
		int n = y.size; 
		var tol = new vector(n);

		if(xlist!=null) xlist.push(x);
		if(ylist!=null) ylist.push(y);



  
		if(a>b) 
			throw new Exception("driver: a>b");

		while(x < b){
			bool check = true; 
			if(x+h > b) h = b-x;  
			(yh, erv) = rkstep.rkstep12(f, x, y, h); 
			
			for(int i = 0; i< n; i++){
				tol[i] =Max(acc,Abs(yh[i])*eps)*Sqrt(h/(b-a));   
				check = (check && tol[i] > erv[i]);
			}
			
			ratioMin = tol[0]/Abs(erv[0]); 
			for(int i = 1; i < n; i++) ratioMin = Min(ratioMin, tol[i]/Abs(erv[i]));

			if(check){
				x +=h;
				y = yh; 
			if(xlist!=null)	xlist.push(x);
			if(ylist!=null)	ylist.push(y);
			} 

			h *=Min(Pow(ratioMin,0.25)*0.95,2); 
		}
		
		return y;  
	}		
}
