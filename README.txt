The repository include 3 important folders: 
* Exercise 
* Homework 
* Exam project

The test folders named test are made for myself to play with diffrent things. 
They are not important, for the exam. Maybe the are deleted before tha exam. 

For the homewoks each homework is divided into the 3 pars A, B and C. 


/////////////////////////////////////////////////////
////////  Notes for exercies/homeworks ////////////// 
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



