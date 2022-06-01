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
	
	public static (double, double) corputmc(Func<vector, double> f, vector a, vector b, int N){
		double V=1, fx, sum = 0, sum2 = 0;
		int dim = a.size, Nx =N; //Dimention of vector/integral
		vector x = new vector(dim); //Point

		for(int i = 0; i<dim; i++) V *= b[i]-a[i]; //Calculate volume 
		
		for(int i = 0; i<N; i++){
			for(int j=0; j<dim; j++){ 
				x[j] = a[j]+corput(i+1,j)*(b[j]-a[j]); //Creates a vector betveen a and b 
			}		
			fx = f(x); 
			
			// remove singular points
			if(Double.IsInfinity(fx)){
				Write($"Point xi ="); 
				x.print(""); 
				WriteLine($"is removed becuse f(xi) = {fx}");
				fx = 0;   
				Nx --; 
			}
			
			// Sum of f and f^2	
			sum += fx; 
			sum2 += fx*fx;  
		}

		double I = V/Nx * sum; // Integral result
		double sigma2 = sum2/Nx-sum/Nx*sum/Nx; 
		double error = V*Sqrt(sigma2)/Sqrt(Nx); 
		return(I,error);			
	

	}
	
	static double corput(int n, int dim){
		int[] bases = {2, 3, 5,7,11,13,17,19,23,29}; 
		int b = bases[dim]; 
		double q = 0, bk= (double) 1/b;		
		while(n>0){
			q += (n%b)*bk; 
			n /= b; 
			bk /= b;
		}
		return q; 
	}
}


		
