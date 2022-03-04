using static System.Console;
using static System.Math;

public class vec{
	public double x,y,z;

	//constructors:
	public vec(){ x=y=z=0; }
	public vec(double a,double b,double c){ 
		x=a;
		y=b;
		z=c; 
	}
	
	//operators (part A):
	public static vec operator*(vec v, double c){
		return new vec(c*v.x,c*v.y,c*v.z);
	}
	public static vec operator*(double c, vec v){return v*c;}
	public static vec operator+(vec u, vec v){
		return new vec(u.x+v.x, u.y+v.y, u.z+v.z);
	}
	public static vec operator-(vec u, vec v){
		return new vec(u.x-v.x, u.y-v.y, u.z-v.z);
	}
	public static vec operator-(vec u){
		return new vec(-u.x, -u.y, -u.z);
	}
	
	//methods (part B):
	public static double dot(vec u, vec v){		// Dot product of two vectors
		return u.x * v.x + u.y * v.y + u.z * v.z;
	}
	public static vec cross(vec u, vec v){		// Cross prduct of 2 vectors
		return new vec(u.y*v.z - u.z*v.y, u.z*v.x - u.x*v.z, u.x*v.y - u.y*v.x);
	}
	public static double norm(vec u){		// Norm of vectora
		return Sqrt(u.x*u.x + u.y*u.y + u.z*u.z);
	}

	public override string ToString(){
	return x + " " + y + " " + z;
	}

	//print methods:
	public void print(string s){
		Write(s);
		WriteLine($"{x} {y} {z}");
	}

	public void print(string s, string t){
		Write(s);
		Write($" {x} {y} {z} ");
		WriteLine(t);
	}
	public void print(){
		this.print("");
	}
}
