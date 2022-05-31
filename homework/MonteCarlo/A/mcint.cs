using System; 
using static System.Console;
using static System.Math;

public class mcint{
	public static (double, double) plainmc(Func<vector, double> f, vector a, vector b, int N){

		double V=1, fx, sum = 0, sum2 = 0;

		int dim = a.size; //Dimention of vector/integral
		vector x = new vector(dim); //Point
  
		Random rnd = new Random(); 
		for(int i = 0; i<dim; i++) V *= b[i]-a[i]; //Calculate volume 
		
		for(int i = 0; i<N; i++){
			for(int j=0; j<dim; j++) 
				x[j] = a[j]+rnd.NextDouble()*(b[j]-a[j]); //Creates a vector betveen a and b 

			fx = f(x); 
			sum += fx; 
			sum2 += fx*fx;  
		}
		double I = V/N * sum; // Integral result
		double sigma2 = sum2/N-sum/N*sum/N; 
		double error = V*Sqrt(sigma2)/Sqrt(N); 
		return(I,error); 
	} 
}
