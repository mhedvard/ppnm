The repository include 3 folders: 
* Exercise 
* Homework 
* Exam

The homewoks each homework is divided into the 3 parts A, B and C.
(For some of the homeworks part C is not made, and the the C forlder will not exist for these) 


Points for homework projects: 

#	homework		A	B	C	Σ
1	vec			6	3	1	10
2	Input/Output		6	3	1	10
3	generic list		6	3	1	10
4	plots			6	3	 	9
5	splines			6	3	1	10
6	linear equations	6	3	1	10
7	least-sqares		6	3	1	10
8	eigenvalues		6	3	 	9
9	ODE			6	3	 	9
10	quadratures		6	3	 	9
11	montecarlo		6	3	 	9

Total Points: 105

 

/////////////////////////////////////////////////////
////////  Notes - Makefile ////////////////////////// 
/////////////////////////////////////////////////////
This section is most made as noted for myself, to remember how the code there is copyed multiple times works. 

/// Makefile /// 
To make the writing of the makefile faster I have used the following line multiple times, 
so that a large part of my makefile can be made by copy paste: 

mcs -target:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

here "$(addprefix -r:,$(filter %.dll,$^)) " adds the prefix -r in front of all the dll.files 
where $(filter %.dll,$^) filters out the dll files. 
In the same manner $(filter %.cs,$^) filter out the cs file. 
$^ referes to the prerequis (The listed files)   



