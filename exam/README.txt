Exam problem 20: Akima sub-spline
Implement the Akima (sub-)spline interpolation. 
See the section "Akima sub-spline interpolation" in the book for the inspiration.

I have divided the solution into 3 parts. 

InplementAkima: 
Here the Akima sub-spline method is implemented and tested on the function sin(x).
The method is also used to determine the derivative and the integral (from 0 to x). 
These are compared to the analytical solution. 

RungesPhen: 
Runge’s phenomenon is known for polynomial interpolation, where large oscillation is shown close to the endpoint.
The Akima sub-spline is tested on a data set and compared to the polynomial interpolation. 
It is shown that Runge’s phenomenon does not appear for the Akima sub-spline. 

Wiggle: 
The cubic spline will in some situations show wiggles. 
The sub-spline methods will typically try to minimize this. 
The cubic spline and Akima sub-spline are tested against each other, 
where the wiggles are seen for the cubic spline but not for the Akima sub-spline. 
The cubic spline (cspline.cs) it taken from the homework splines.

The solution for each part is shown in the Plot.png file. 
The Out.txt file gives a short description of the case, and the data points used are listed. 
In the *.dat files the results are saved, and then used to make the plots.   

