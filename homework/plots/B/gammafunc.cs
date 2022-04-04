using System;
using static System.Console;
using static System.Math;

static class main{
	static double gamma(double x){
		///single precision gamma function (Gergo Nemes, from Wikipedia)
		if(x<0)	
			return PI/Sin(PI*x)/gamma(1-x);
		if(x<9)
			return gamma(x+1)/x;
	
		double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
		return Exp(lngamma);
	} 

	static void  Main(){
		for(double x =-3.50; x<=3.50; x+=0.01)
			WriteLine($"{x}	{gamma(x)}");
	}
}
