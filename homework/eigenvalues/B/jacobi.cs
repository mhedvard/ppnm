using System; 
using static System.Console;
using static System.Math;

public class jacobi{	
	static void timesJ(matrix A, int p, int q, double theta){
		double aip,aiq;
		double c = Cos(theta);
		double s = Sin(theta);
		for(int i=0; i<A.size1; i++){
			aip = A[i,p];
			aiq = A[i,q];
			A[i,p]= c*aip - s*aiq;
			A[i,q]= s*aip + c*aiq;
		}
	}	

	static void Jtimes(matrix A, int p, int q, double theta){
		double apj, aqj;
		double c = Cos(theta);
		double s = Sin(theta);
		for(int j=0; j<A.size2; j++){
			apj = A[p,j];
			aqj = A[q,j];
			A[p,j]= c*apj + s*aqj;
			A[q,j]= - s*apj + c*aqj;
		}
	}	

	static public (vector,matrix) cyclic(matrix A){
		matrix D = A.copy(); 
		int n = D.size1;
		var V = matrix.id(n); 
	
		/*
		double diff = 1;
		double diag0 = 0;
		double diag1 = 0;
		for(int i = 0; i<n; i++)
			diag1 += Abs(D[i,i]);
		*/ //Alternative convert criterium (snall sum of aff diagonals)
		double offDiag = 0; 
		for(int i=0; i<A.size1; i++){
			for(int j = 0; j< A.size2; j++){
				if(i!=j)
					offDiag+=Abs(D[i,j]);
			}
		}
		
		while(offDiag>1e-6){
			for( int i = 0; i < n; i++){
				for(int j=0; j < i; j++){
					double theta = 0.5*Atan2(2*D[i,j],D[j,j]-D[i,i]);
					Jtimes(D,i,j,-theta);
					timesJ(D,i,j,theta);
					timesJ(V,i,j,theta);
				}
			}
		//Alternative convert criterium (snall sum of aff diagonals)
			offDiag = 0; 
			for(int i=0; i<A.size1; i++){
				for(int j = 0; j< A.size2; j++){
					if(i!=j)
						offDiag+=Abs(D[i,j]);
				}
			}
		/*
			diag0 = diag1; 
			diag1 = 0;
			for(int i = 0; i<n; i++)
				diag1 += Abs(D[i,i]); 
			diff = Abs(diag1-diag0);
		*/			
		}
		// Convert matrix D to a vector with the eignevalues. 
		vector eig; 
		eig = D.diag();
		return (eig,V);
	} 
}
