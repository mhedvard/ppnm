using System; 
using static System.Console; 
using static System.Math; 
//using static matrix;
//using static vector;  

class main{
	static void Main(){
		int n=3,m=3; 
		WriteLine("Generate matrix A.");
		matrix A = new matrix(n,m);

		Random rnd = new Random(); 
		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
				A[i,j]=rnd.Next(10);
			}
		}

		WriteLine("Matrix A:");
		A.print();

		WriteLine("Inverse of matrix A.");
		QRGS qrgs = new QRGS(A);
		var B = qrgs.inverse(); 
		WriteLine("B = A^-1 :");
		B.print();
 
	
		WriteLine("Test that AB =I:");
		var AB = A*B;
		AB.print();

		WriteLine("");
		WriteLine("Calculate determinant of A:");
		double DetA = qrgs.determinant();
		WriteLine($"Det(A) = {DetA}");
		
	}
}
