using System; 
using static System.Console;
using static System.Math;


public class lsfit{
	public vector c; 
	public matrix cov;  
	public lsfit(Func<double,double>[] fs, vector x, vector y, vector dy){
		int n = x.size, m = fs.Length; 
		var A = new matrix(n,m); 
		var b = new vector(n); 
		for( int i = 0; i<n; i++){
			b[i] = y[i]/dy[i]; 
			for(int k = 0; k<m; k++)
				A[i,k]=fs[k](x[i])/dy[i];
		}
		var qrgs = new QRGS(A); 
		c = qrgs.solve(b);
	
		var invA = qrgs.inverse();
		cov = invA*invA.T;
	}
}
