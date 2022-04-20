Out.txt:main.exe
	mono main.exe > Out.txt

main.exe:main.cs matrix.dll jacobi.dll vector.dll
	mcs -target:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

jacobi.dll:jacobi.cs matrix.dll vector.dll
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

matrix.dll:matrix.cs vector.dll
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

vector.dll:vector.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	$(RM) *.dll *.exe *.png *.txt *.dat log*
