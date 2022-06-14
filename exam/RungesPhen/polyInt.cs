using System; 
using static System.Console; 

public static class polyInt{
	public static double P(double[] x, double[] y, double z)
	{
		double s = 0, p; 
		for(int i = 0; i<x.Length; i++){
			p = 1; 
			for(int k = 0; k<x.Length; k++)
				if(k!=i) p*=(z-x[k])/(x[i]-x[k]);
			s+=y[i]*p;	
		}
		return s;
	}


}
