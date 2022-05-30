using System; 
using static System.Console; 
using static System.Math; 
using static System.Double;

public class integrate{	
	public static double Integrate(Func<double, double> f, double a, double b, double d = 0.001, double e = 0.001, double f2 = NaN, double f3 = NaN){
		double[] x = {(double) 1/6, (double) 2/6, (double) 4/6, (double) 5/6};
		double[] w = {(double) 2/6, (double) 1/6, (double) 1/6, (double) 2/6};
		double Q=0, q=0;
		double[] fval =  {NaN, f2, f3, NaN}; 
		
		for(int i = 0; i < 4; i++){
			if(IsNaN(fval[i]))  
				fval[i] = f(a+(b-a)*x[i]); 
			Q += (b-a)*w[i]*fval[i];
			q += (b-a) * 0.25*fval[i]; 
		}
		if(Abs(Q-q) <= d+e*Abs(Q)) 
			return Q;
		else 
			return Integrate(f, a, (a+b)/2, d/Sqrt(2), e, fval[0], fval[1]) + Integrate(f, (a+b)/2, b, d/Sqrt(2), e, fval[2], fval[3]); 
	}
} 
