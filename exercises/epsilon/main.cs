using System;
using static System.Console;
using static System.Math;

class main{
public static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9){
	if (Abs(a-b)<tau || Abs(a-b)/(Abs(a)+Abs(b))<epsilon) {
		return true;
	}
	else{ 
		return false;
	}
}
public static void Main(){
/*
	int i=1; 
	while(i+1>i) {i++;};
	Write($"my max int = {i} should be equal {int.MaxValue}\n" );	

	i=0; 
	while(i-1<i) {i--;};
	Write($"my max int = {i} should be equal {int.MinValue}\n");	

	double x=1;
	while(1+x != 1){x/=2;} x*=2;
	Write($"my machine epsilon for double = {x} should be approxomate {Pow(2,-52)}\n");	

	float y=1;
	while(1+y!=1){y/=2;} y*=2;
	// float y=1F; while((float)(1F+y) != 1F){y/=2F;} y*=2F;
	Write($"my machine epsilon for float = {y} should be approxomate {Pow(2,-23)}\n");	

	int n=(int)1e6;
	double epsilon = Pow(2,-52);
	double tiny = epsilon/2; 
	double sumA=0, sumB=0;
	sumA+=1;
	for(int k=0;k<n;k++){sumA+=tiny;}
	WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");

	for(int k=0;k<n;k++){sumB+=tiny;} sumB+=1;
	WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");
*/
	WriteLine($"approx = {approx(1.1, 1.1)} should be true");
	WriteLine($"approx = {approx(1.1, 1.2)} should be false");
	WriteLine($"approx = {approx(1.1, 1.2, 0.5)} should be true");
	WriteLine($"approx = {approx(1.1, 1.2, 0.01)} should be false");
	WriteLine($"approx = {approx(1.1, 1.2, 0.01,0.5)} should be true");


}
}

