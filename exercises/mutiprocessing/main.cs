using System;
using static System.Console;
using System.Threading;
using static sum; 
using System.Threading.Tasks;
using System.Diagnostics;

class main{
	public static void Main(){
	
	
		int start = 1;
		int end = 10000000; 

		WriteLine("Calculate without using threads");
		var watch = Stopwatch.StartNew();		
		data a = new data(); 
		a.a = start; a.b = end;
		watch.Restart();
		harmonic_sum(a);
		watch.Stop();
		WriteLine($"harmonic sum from {a.a} to {a.b} equals {a.sum}");
		WriteLine($"Time: {watch.ElapsedMilliseconds} ms");


		WriteLine("Calculate using 1 thread");
		data x = new data();
		x.a = start; x.b = end; /* prepare data */
		Thread t = new Thread(harmonic_sum); /* prepare a thread */
		watch.Restart();
		t.Start(x); /* run the t-thread on a (hopefully) separate processor */
		t.Join(); /* join the t-thread with the main thread */
		watch.Stop();
		WriteLine($"harmonic sum from {x.a} to {x.b} equals {x.sum}");
		WriteLine($"Time: {watch.ElapsedMilliseconds} ms");


		int N = end/2;
		WriteLine($"Calculate using 2 threads seperated at {N}");
		data l = new data();
		l.a = start; l.b = N;
		data m = new data(); 
		m.a = N+1; m.b = end; 
		Thread t1 = new Thread(harmonic_sum); 
		Thread t2 = new Thread(harmonic_sum);
		watch.Restart();
		t1.Start(l); 
		t2.Start(m);
		t1.Join(); 
		t2.Join();
		watch.Stop();
		WriteLine($"harmonic sum from {l.a} to {m.b} equals {l.sum+m.sum}");
		WriteLine($"Time: {watch.ElapsedMilliseconds} ms");
		

		WriteLine("Calculate using Parallel.For");
		data y = new data();
		y.a = start; y.b = end; /* prepare data */
		watch.Restart();
		Parallel.For(y.a,y.b, i=> y.sum += 1.0/i); 
		WriteLine($"harmonic sum from {y.a} to {y.b} equals {y.sum}");
		
		watch.Stop();
		WriteLine($"Time: {watch.ElapsedMilliseconds} ms");

	}
}
