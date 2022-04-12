using System; 
using static System.Console;
using static System.Math;

public class qspline {
	double[] x,y,b,c,d;
	public qspline(double[] xs, double[] ys){
		x = xs; 
		y = ys;
		int n = x.Length;

		b = new double[n];
		c = new double[n-1];
		d = new double[n-1];
		
		var h = new  double[n-1];
		var p = new  double[n-1];
		
		var B = new  double[n];
		var D = new  double[n];
		var Q = new  double[n-1];

		var Dt = new double[n];
		var Bt = new double[n];
		

		for(int i = 0; i < n-1; i++){
			h[i] = x[i+1]-x[i];
			p[i] = (y[i+1]-y[i])/h[i]; //dydx
		}	
		
		D[0] = 2; D[n-1]=2; Q[0] = 1; B[0] = 3*p[0]; B[n-1]=3*p[n-2];
		for(int i = 0; i < n-2; i++){
			D[i+1] = 2*h[i]/h[i+1]+2;
			Q[i+1] = h[i]/h[i+1];
			B[i+1] = 3*(p[i]+p[i+1]*h[i]/h[i+1]);
		}

		
		Dt[0] = D[0]; Bt[0] =B[0];
		for(int i = 1; i < n; i++){
			Dt[i] = D[i]-Q[i-1]/D[i-1];
			Bt[i] = B[i] - Bt[i-1]/Dt[i-1];
		}

		b[n-1] = Bt[n-1]/Dt[n-1];
		for(int i=n-2; i>=0; i--)
			b[i]=(Bt[i]-Q[i]*b[i+1])/Dt[i];


		for(int i=0; i<n-1; i++){
			c[i]=(-2*b[i]-b[i+1]+3*p[i])/h[i];
			d[i]=(b[i]+b[i+1]-2*p[i])/Pow(h[i],2);
		}


		// Write out b, c, d values to file
		var WriteBCval = new System.IO.StreamWriter("bcval.txt", append:true);
		WriteBCval.WriteLine("b	c	d");	
		for(int i = 0; i<(x.Length-1);i++)
			WriteBCval.WriteLine($"{b[i]}	{c[i]}	{d[i]}");
		WriteBCval.WriteLine("");
		WriteBCval.Close();
	}
	
	public double spline(double z){
		int i = binsearch(z);
		return y[i] + b[i]*(z-x[i])+c[i]*Pow((z-x[i]),2)+d[i]*Pow((z-x[i]),3);
	}


	public double derivative(double z){
		int i = binsearch(z); 
		return b[i] +2 * c[i] *(z-x[i]) + 3 * d[i] * Pow(z-x[i],2);	
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
		return (z-x[i])/12*(12*y[i] + 6*b[i]*(z-x[i]) + 4*c[i]*Pow(z-x[i],2) + 3*d[i] *(Pow(z,3)-3*x[i]*Pow(z,2) + 3*z*Pow(x[i],2) -Pow(x[i],3)));
	}

}

