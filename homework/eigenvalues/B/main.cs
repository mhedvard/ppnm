using System; 
using static System.Console; 
using static System.Math; 
using System.IO;
class main{
	static void Main(){
	// Investigate convergence of your energies with respect to and dr.
		StreamWriter sw_dr = new StreamWriter("drConv.dat");
		for(int N = 10; N<200; N+=5){
			double rmax = 100; 
			var H = hem(rmax,N);
			// Diagonalize the matrix using your Jacobi routine
			matrix V; 
			vector eig; 
			(eig,V) = jacobi.cyclic(H);
			sw_dr.WriteLine($"{N}  {eig[0]} {eig[1]} {eig[2]}	-0.5	-0.125	-0.055" );
		}
		sw_dr.Close();


	// Investigate convergence of your energies with respect to rmax.
		StreamWriter sw_rmax = new StreamWriter("rmaxConv.dat");
		for(double rmax = 10; rmax<200; rmax+=5){
			int N = 100; 
			var H = hem(rmax,N);
			// Diagonalize the matrix using your Jacobi routine
			matrix V; 
			vector eig; 
		
			(eig,V) = jacobi.cyclic(H);
			sw_rmax.WriteLine($"{rmax}  {eig[0]} {eig[1]} {eig[2]}");
		}
		sw_rmax.Close();
	}

	static matrix hem(double rmax, int N){
		// Boild the Hamiltoanian matrix
		double dr = rmax/(N+1);
		var r = new vector(N); 
		var H = new matrix(N,N); 
		for(int i=0;i<N;i++)
			r[i]=dr*(i+1);
		for(int i=0; i<N; i++){
			H[i,i] = 1/dr/dr-1/r[i]; 
			if(i>0)	H[i,i-1]=- 0.5/dr/dr; 
			if(i<N-1) H[i,i+1]=-0.5/dr/dr;
		} 
		return H; 
	}
}
