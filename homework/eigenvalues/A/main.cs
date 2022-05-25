using System; 
using static System.Console; 
using static System.Math; 

class main{
	static void Main(){
		// Create real symetric matrix A
		int n = 3; 
		matrix A = new matrix(n,n);
		var rnd = new Random(); 
		for(int i =0; i<n; i++){
			for(int j = 0; j <=i; j++){
				A[i,j] = rnd.Next(10);
				A[j,i] = A[i,j];
			}
		}
		matrix D = A.copy();

		A.print("Matrix used for the test");		
		
		// Find eigenvalues and vectors
		(vector eig, matrix V) = jacobi.cyclic(D);


		WriteLine(""); 
		eig.print("Eigenvalues e =");

		WriteLine("");
		V.print("Orthogonal matrix of eigenvectors V = ");
		
		D = new matrix(eig);	
		WriteLine(""); 
		D.print("Diagonal matrix with the corresponding eigenvalues D = ");

		//Test
		WriteLine("");
		matrix test1 = V.T*A*V;
		test1.print("Test: V^TAV=D:");


		WriteLine("");
		var test2 = V*D*V.T;
		test2.print("Test: VDV^T=A:");

		WriteLine("Test: V^TV=I:");
		var test3 = V.T*V;
		test3.print();

		WriteLine($"");
		var test4 = V*V.T;
		test4.print("Test: VV^T=I:");
	}
}
