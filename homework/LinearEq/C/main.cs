using System; 
using static System.Console; 
using static System.Math; 
using System.Diagnostics;

class main{
	static void Main(){
		var watch = new Stopwatch();
		Random rnd = new Random(); 
		for(int n=20; n<1000; n+=20){
			matrix A = new matrix(n,n); 
			watch.Restart();
				for(int i=0; i<n; i++)
					for(int j=0; j<n; j++)
						A[i,j]=rnd.Next(10);
			watch.Restart();
			QRGS qrgs = new QRGS(A);
			watch.Stop();
			WriteLine($"{n} {watch.ElapsedMilliseconds}");
		}
		
	}
}
