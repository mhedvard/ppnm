using System; 
using static System.Console;
using static System.Math;

public class linterp{
	public static double linterpPoint(double[] x, double[] y, double z){
		int i = binsearch(x, z);
		double dx = x[i+1]-x[i]; 
		if(!(dx > 0))
			throw new Exception("dx<=0, so there is a mistake somewhere");
		double dy = y[i+1]-y[i];
		return y[i]+dy/dx*(z-x[i]); 
	}

	public static double linterpInteg(double[] x, double[] y,  double z){ 
		if(x[0] > z || x[x.Length-1] < z) 
			throw new Exception("binsearch: bad z");

		double val = 0;
		int i = 0;

		while(x[i+1] < z){
			double dx = x[i+1]-x[i]; 
			if(!(dx >= 0)) throw new 
				Exception("dx<0, so there is a mistake somewhere");
			double dy = y[i+1]-y[i];
			val += y[i]*dx + 0.5 * dy * dx;
			i++;   
		}
		
		double dxz = z - x[i]; 
		if(!(dxz >= 0)) 
			throw new Exception("dx<0, so there is a mistake somewhere");
		double dyz = linterpPoint(x,y,z)- y[i];
		val += y[i]*dxz + 0.5 * dyz * dxz;
		return val;			
	}	

	private static int binsearch(double[] x, double z){
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

