Plot.png:plot.ppl results.dat
	pyxplot $<


results.dat:main.exe
	mono main.exe > results.dat

main.exe:main.cs ode.dll vector.dll
	mcs -target:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

ode.dll:ode.cs vector.dll
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

vector.dll:vector.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


clean:
	$(RM) *.dll *.exe *.png *.txt *.dat
