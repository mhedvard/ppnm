using System; 
using static System.Console;
using static System.Math;

public class akima{
	double[] x, y, a, b, c, d;
	public akima(double[] xs, double[] ys){
		if(xs.Length != ys.Length)
			throw new Exception("The number of x and y values must be the same.");
		int n = xs.Length;  //Number of points
		
		x = new double[n];
		y = new double[n];
		var dx = new double[n-1];
		var dy = new double[n-1];
		var Sm = new double[n];
		var p = new double[n-1];
		var w = new double[n-1];
		a = new double[n-1];
		b = new double[n-1];
		c = new double[n-1];
		d = new double[n-1];

	
		for(int i = 0; i<n ; i++){
			x[i] = xs[i]; 
			y[i] = ys[i];
		}



		for(int i = 0; i < n-1; i++){
		dx[i] = x[i+1] - x[i];
		if(!(dx[i] > 0))
			throw new Exception("dx[i]<=0");
		dy[i] = y[i+1] - y[i];
		p[i] = dy[i]/dx[i]; 
		}
			
		w[0] = 0; //w0 does not exist. Here w[0] is made to make index notation easy programing
		for(int i = 1; i<n-1; i++) w[i] =  Abs(p[i]-p[i-1]);

		Sm[0] = p[0];
		Sm[1] = 0.5*p[0]+0.5*p[1]; 
		
		for(int i = 2; i < n - 2; i++){
			if(w[i+1] + w[i-1] == 0) Sm[i] = (p[i-1] + p[i])/2; 
			else Sm[i] = (w[i+1]*p[i-1]+w[i-1]*p[i])/(w[i+1]+w[i-1]);
		}
		Sm[n-2] = 0.5*p[n-2] + 0.5*p[n-3];
		Sm[n-1] = p[n-2];

		for(int i = 0; i<n-1; i++){
			a[i] = y[i];
			b[i] = Sm[i]; 
			c[i] = (3*p[i]-2*Sm[i]-Sm[i+1])/dx[i]; 
			d[i] = (Sm[i]+Sm[i+1]-2*p[i])/(dx[i]*dx[i]);
		}
	}

	public double getS(double z){
		int i = binsearch(z);
		return a[i] + b[i]*(z-x[i]) + c[i]*Pow((z-x[i]),2) + d[i]*Pow((z-x[i]),3);  
	}	
	
	public double derivative(double z){
		int i = binsearch(z);
		return b[i] +2 * c[i] *(z-x[i]) + 3 * d[i] * Pow(z-x[i],2);
	}  

	public double integral(double z) {
		int j = binsearch(z); 
		double val = 0; 
		for(int i = 0; i < j; i++)
			val +=  partint(i,x[i+1]);
		val +=  partint(j,z);
		return val;
	}

	double partint(int i, double z){ 
		// integra of subpline fom xi to z
		return (z-x[i])/12*(12*a[i] + 6*b[i]*(z-x[i]) + 4*c[i]*Pow(z-x[i],2) + 3*d[i] *Pow(z-x[i],3));
	}

	public int binsearch(double z){
		/*Locate the idenx i for which x_i<=z<=x_(i+1)*/
		int i = 0, j = x.Length-1;
		
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
