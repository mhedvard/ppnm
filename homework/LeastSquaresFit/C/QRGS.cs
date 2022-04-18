using System; 
using static System.Console;
using static System.Math;
using static matrix;

public class QRGS{
	public matrix Q,R;
	public QRGS(matrix A){
		// run the Gram-Schmidt proces
		int m = A.size2;
		Q = A.copy();
		R = new matrix(m,m);
		for(int i=0; i<m; i++){
			R[i,i] = Q[i].norm();
			Q[i] /= R[i,i];
			for(int j=i+1; j < m; j++){
				R[i,j] = Q[i].dot(Q[j]);
				Q[j] -= Q[i]*R[i,j];
			}
		} 

	}
	
	public vector solve(vector b){
	//  Back-substitute Q^T*b 
		var c = Q.T*b; 
		for(int i = c.size-1; i>=0; i--){
		double sum = 0; 
			for(int k = i+1; k<c.size; k++)
				sum += R[i,k]*c[k];
			c[i] = (c[i]-sum)/R[i,i];
		} 
		return c; 
	}
	
	public matrix inverse(){
		// return the inverse matrix (part B)
		int n = Q.size1; 
		int m = Q.size2;
		var B = new matrix(m,n);
		var I = id(n); 
		for(int i = 0; i<n; i++)
			B[i] = solve(I[i]);
		return B;

	}
	
	public double determinant(){
		double det = R[0,0]; 
		for(int i = 1; i < R.size1; i++)
			det *= R[i,i];
		return det;
	}
}
