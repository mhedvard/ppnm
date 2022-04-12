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

		for(int i = 0; i < (x.Length-1); i++){
			dx[i] = x[i+1]-x[i];
			p[i] = (y[i+1]-y[i])/dx[i]; //dydx
		}	
		

		for(int i = 0; i < (x.Length-2); i++){
			c[i+1] = 1/dx[i+1]*(p[i+1]-p[i]-c[i]*dx[i]);
		}

		c[x.Length-2]/=2;
		for(int i = x.Length-3; i >= 0; i--){
			c[i] = 1/dx[i]*(p[i+1]-p[i]-c[i+1]*dx[i+1]); 
		}

		b[0] = p[0] - c[0] *dx[0];
		for(int i = 0; i < (x.Length-2); i++){
			b[i+1] = p[i+1] - c[i+1] *dx[i+1]; 
		}
		
		// Write out b, c values to file
		var WriteBCval = new System.IO.StreamWriter("bcval.txt", append:true);
		WriteBCval.WriteLine("b	c	p");	
		for(int i = 0; i<(x.Length-1);i++)
			WriteBCval.WriteLine($"{b[i]}	{c[i]}	{p[i]}");
		WriteBCval.WriteLine("");
		WriteBCval.Close();
	}
	
	public double spline(double z){
		int i = binsearch(z);
		return y[i] + b[i]*(z-x[i])+c[i]*Pow((z-x[i]),2);
	}


	public double derivative(double z){
		int i = binsearch(z); 
		return b[i] +2 * c[i] *(z-x[i]);	
	}


	public double integral(double z){
		int j = binsearch(z); 
		double val = 0; 
		for(int i = 0; i < j; i++)
			val +=  partint(i,x[i+1]);
		val +=  partint(j,z);
		return val;
	}

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
	double partint(int i, double z){
		return (z-x[i])/6*(2*c[i]*Pow(z,2)-4*c[i]*z*x[i]+2*c[i]*Pow(x[i],2)+2*b[i]*(z-x[i])+6*y[i]);
	}

}

