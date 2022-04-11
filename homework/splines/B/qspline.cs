using System; 
using static System.Console;
using static System.Math;

public class qspline {
	double[] x,y,b,c;
	public qspline(double[] xs, double[] ys){
		x = xs; 
		y = ys;
		b = new double[x.Length-1];
		c = new double[x.Length-1];
		
		var dx = new  double[x.Length-1];
		var p = new  double[x.Length-1];
		c[0] = 0;

		for(int i = 0; i < (x.Length-2); i++){
			dx[i] = x[i+1]-x[i];
			p[i] = (y[i+1]-y[i])/dx[i]; //dydx
		}	
		
		for(int i = 0; i < (x.Length-2); i++){
			c[i+1] = 1/dx[i+1]*(p[i+1]-p[i]-c[i]*dx[i]);
			b[i] = p[i] - c[i] *dx[i]; 
		}
	}
	
	public double spline(double z){
		int i = binsearch(z);
		return y[i] + b[i]*(z-x[i])+c[i]*Pow((z-x[i]),2);
	}


	//public double derivative(double z){/* evaluate the derivative */}
	//public double integral(double z){/* evaluate the integral */}

	int binsearch(double z){
		/*Locate the idenx i for which x_i<=z<=x_(i+1)*/
		int i = 0;
		int j = x.Length-1;
		
		if(x[0] > z || x[j] < z)
			throw new Exception("binsearch: bad z");
 
		while(j - i > 1){
			int m = (i+j)/2; 
			if(z > x[m]) i = m; 
			else j = m; 
		}
		return i; 
	}

}

