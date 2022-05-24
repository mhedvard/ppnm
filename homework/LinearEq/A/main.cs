using System; 
using static System.Console; 
using static System.Math; 
//using static matrix;
//using static vector;  

class main{
	static void Main(){
		int n=7,m=7; 
		WriteLine("Generate matrix A and vector b.");
		matrix A = new matrix(n,m);
		vector b = new vector(n); 

		Random rnd = new Random(); 
		
		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
				A[i,j]=rnd.Next(10);
			}
		}
		for(int i=0; i<n; i++)
			b[i] = rnd.Next(10);

		WriteLine("Matrix A:");
		A.print();
		WriteLine("");
		WriteLine("Vector b:");
		b.print();
		WriteLine("");

		WriteLine("Factorize A into QR.");
		QRGS qrgs = new QRGS(A);
		matrix R = qrgs.R;
		matrix Q = qrgs.Q;
		WriteLine("Right triangular matris R:");
		R.print(); 
		WriteLine("Orthogonal matrix Q:");
		Q.print();
		WriteLine("");

		WriteLine("Test that Q^T*Q =I:");
		var QTQ = Q.T*Q;
		QTQ.print();
		WriteLine("");

		WriteLine("Test that QR - A = [0]:");
		var QRA = Q*R-A;
		QRA.print();
		WriteLine("");

		
		WriteLine("Solve QRx = b.");
		var x = qrgs.solve(b);
		WriteLine("Result for x:");
		x.print();
		WriteLine("");

		WriteLine("Check Ax = b.");
		var Ax = A*x;
		WriteLine("");
	
		WriteLine("Result for Ax:");
		Ax.print(); 
		WriteLine("Vextor b:");
		b.print();
 
		
	}
}
