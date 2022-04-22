using System; 
using static System.Console; 
using static System.Math; 
using System.IO;
class main{
	static void Main(){
	// Investigate convergence of your energies with respect to and dr.
		StreamWriter sw_dr = new StreamWriter("drConv.dat");
		for(double dr = 0.1; dr<1; dr+=0.1){
			double rmax = 10; 
			var H = hem(rmax,dr);
			// Diagonalize the matrix using your Jacobi routine
			matrix V; 
			vector eig; 
			(eig,V) = jacobi.cyclic(H);
			sw_dr.WriteLine($"{dr}  {eig[0]} {eig[1]} {eig[2]}	-0.5	-0.125	-0.055" );
		}
		sw_dr.Close();


	// Investigate convergence of your energies with respect to rmax.
		StreamWriter sw_rmax = new StreamWriter("rmaxConv.dat");
		for(double rmax = 1; rmax<20; rmax+=2){
			double dr = 0.2; 
			var H = hem(rmax,dr);
			// Diagonalize the matrix using your Jacobi routine
			matrix V; 
			vector eig; 
		
			(eig,V) = jacobi.cyclic(H);
			sw_rmax.WriteLine($"{rmax}  {eig[0]} {eig[1]} {eig[2]}	-0.5	-0.125	-0.055");
		}
		sw_rmax.Close();
	
	}

	static matrix hem(double rmax, double dr){
		// Boild the Hamiltoanian matrix
		int N = (int) (rmax/dr)-1;
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
