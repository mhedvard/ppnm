using System; 
using static System.Console; 
using static System.Math; 
using System.IO;
class main{
	static void Main(){
	// Investigate convergence of your energies with respect to and dr.
		StreamWriter sw_dr = new StreamWriter("drConv.dat");
		for(int npoints = 10; npoints<200; npoints+=10){
			double rmax = 30;
			double dr = rmax/(npoints+1);
 
			var H = hem(rmax,npoints);
			H.print("\n Matrix H \n"); 
			// Diagonalize the matrix using your Jacobi routine
			(vector eig, matrix V) = jacobi.cyclic(H);
			V.print("\n matrix V \n"); 
			eig.print("\n vector eig \n" ); 
			sw_dr.WriteLine($"{dr}  {eig[0]} {eig[1]} {eig[2]}	-0.5	-0.125	-0.055" );
		}
		sw_dr.Close();


	// Investigate convergence of your energies with respect to rmax.
		StreamWriter sw_rmax = new StreamWriter("rmaxConv.dat");
		for(double rmax = 1; rmax<30; rmax+=2){
			double dr = 0.2;
			int npoints = (int) (rmax/dr)-1; 
			var H = hem(rmax,npoints);
			// Diagonalize the matrix using your Jacobi routine
			(vector eig, matrix V) = jacobi.cyclic(H);
			sw_rmax.WriteLine($"{rmax}  {eig[0]} {eig[1]} {eig[2]}	-0.5	-0.125	-0.055");
		}
		sw_rmax.Close();



	// Plot the several lowest eigenfunctions and compare with the analytical result..
		StreamWriter sw_eigF = new StreamWriter("eigFunc.dat");
		double rmax1 = 30; 
		double dr1 = 0.2; 
		int npoints1 = (int) (rmax1/dr1)-1;
		vector r1 = new vector(npoints1);
		for(int i=0;i< npoints1;i++)
			r1[i]=dr1*(i+1); 
		matrix H1 = hem(rmax1,npoints1);
		// Diagonalize the matrix using your Jacobi routine
		(vector eig1, matrix V1) = jacobi.cyclic(H1);


		for(int i=0; i<r1.size; i++)
			sw_eigF.WriteLine($"{r1[i]} {V1[0][i]*1.0/Sqrt(dr1)} {-V1[1][i]*1.0/Sqrt(dr1)} {-V1[2][i]*1.0/Sqrt(dr1)}");
		
		
		sw_eigF.WriteLine($"");
		sw_eigF.WriteLine($"");
		//Analytical result
		for(double x=0; x<rmax1; x+=0.01){
			double R1 = x*2*Exp(-x);
			double R2 = x*1.0/Sqrt(2)*(1-1.0/2*x)*Exp(-x/2);
			double R3 = x*2.0/(3*Sqrt(3))*(1-2.0/3*x+2.0/27*x*x)*Exp(-x/3);
			sw_eigF.WriteLine($"{x} {R1} {R2} {R3}");
		}

		sw_eigF.Close();


	}

	static matrix hem(double rmax, int npoints){
		double dr = rmax/(npoints+1);
		vector r = new vector(npoints);
		for(int i=0;i< npoints;i++)
			r[i]=dr*(i+1);
		matrix H = new matrix(npoints,npoints);
		for(int i=0;i<npoints-1;i++){
			matrix.set(H,i,i,-2);
			matrix.set(H,i,i+1,1);
			matrix.set(H,i+1,i,1);
		}
		matrix.set(H,npoints-1,npoints-1,-2);
		H*=-0.5/dr/dr;
		for(int i=0;i<npoints;i++)
			H[i,i]+=-1/r[i]; 
	return (H); 
	}
}
