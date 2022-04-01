public class data { public int a,b; public double sum; } // data to pass to/from harmonic_sum

public class sum{
	public static void harmonic_sum(object o){ // the function to run in a thread
		data x = (data) o; // cast of argument to our data type
		x.sum = 0; 
			for(int i = x.a; i <= x.b; i++) 
				x.sum += 1.0/i;
	}
}


