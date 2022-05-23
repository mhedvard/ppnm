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
	// Maximum representable integer
	int i=1; 
	while(i+1>i) {i++;};
	Write($"My max int = {i} should be equal {int.MaxValue}\n" );	

	// Minimum representable integer
	i=0; 
	while(i-1<i) {i--;};
	Write($"My min int = {i} should be equal {int.MinValue}\n");	

	// Machine epsilon double 
	double x=1;
	while(1+x != 1){x/=2;} x*=2;
	Write($"my machine epsilon for double = {x} should be approxomate {Pow(2,-52)}\n");	
	
	// Machine epsilon float 
	float y=1;
	while(1+y!=1){y/=2;} y*=2;
	Write($"my machine epsilon for float = {y} should be approxomate {Pow(2,-23)}\n");	
	WriteLine("");

	// Calculate sums 
	int n=(int)1e6;
	double epsilon = Pow(2,-52);
	double tiny = epsilon/2; 
	double sumA=0, sumB=0;
	sumA+=1;
	for(int k=0;k<n;k++){
		sumA+=tiny;
		sumB+=tiny;
	}
	sumB+=1;

	WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");
	WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");
	WriteLine(""); 

	// Cheack approx fuction
	WriteLine("Test of approx function");  
	WriteLine($"approx(1.1, 1.1) = {approx(1.1, 1.1)},  should be true");
	WriteLine($"approx(1.1, 1.2) = {approx(1.1, 1.2)},  should be false");
	WriteLine($"approx(1.1, 1.2, 0.5) = {approx(1.1, 1.2, 0.5)},  should be true");
	WriteLine($"approx(1.1, 1.2, 0.01) = {approx(1.1, 1.2, 0.01)},  should be false");
	WriteLine($"approx(1.1, 1.2, 0.01,0.5) = {approx(1.1, 1.2, 0.01,0.5)},  should be true");
	}
}

