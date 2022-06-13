using System; 
using static System.Console;
using static System.Math;

public class akima{
	double[] Sm, x, y, dx, dy, p, w;
	public akima(double[] xs, double[] ys){
		WriteLine("test0");
		if(xs.Length != ys.Length)
			throw new Exception("The number of x and y values must be the same.");
		int n = xs.Length;  //Number of points
		
		x = new double[n];
		y = new double[n];
		dx = new double[n-1];
		dy = new double[n-1];
		Sm = new double[n];
		p = new double[n-1];
		w = new double[n-1];

		WriteLine("test1");
		for(int i = 0; i<n ; i++){
			x[i] = xs[i]; 
			y[i] = ys[i];
		}


		WriteLine("test2");

		for(int i = 0; i < n-1; i++){
		dx[i] = x[i+1] - x[i];
		if(!(dx[i] > 0))
			throw new Exception("dx[i]<=0");
		dy[i] = y[i+1] - y[i];
		p[i] = dy[i]/dx[i]; 
		}
			
		w[0] = 0; //w0 does not exist. Here w[0] is made to make index notation easy programing
		for(int i = 1; i<n-1; i++) w[i] =  Abs(p[i]-p[i-1]);

		WriteLine("test3");
		Sm[0] = p[0];
		Sm[1] = 0.5*p[1]; 
		
		for(int i = 2; i < n - 2; i++){
			if(w[i+1] + w[i-1] == 0) Sm[i] = (p[i-1] + p[i])/2; 
			else Sm[i] = (w[i+1]*p[i-1]+w[i-1]*p[i])/(w[i+1]+w[i-1]);
		}
		Sm[n-2] = 0.5*p[n-2] - 0.5*p[n-3];
		Sm[n-1] = p[n-2];

		WriteLine("test4");
	}

	public double getS(double z){
		int i = binsearch(x,z);
		double ai = y[i];
		double bi = Sm[i]; 
		double ci = (3*p[i]-2*Sm[i]-Sm[i+1])/dx[i]; 
		double di = (Sm[i]+Sm[i+1]-2*p[i])/(dx[i]*dx[i]);
		return ai + bi*(z-x[i]) + ci*Pow((z-x[i]),2) + di*Pow((z-x[i]),3);  
	}

	public int binsearch(double[] x, double z){
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
