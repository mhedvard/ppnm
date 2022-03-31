using System;
using static System.Console;
using static System.Math;

class main{
	static void Main(){

		
		for(double k=1; k<=3; k++){
			System.Func<double,double> f = delegate(double x){
				return Sin(k*x);
			};

			table.make_table(f, 0, PI, PI/10);
		}
	}
}

