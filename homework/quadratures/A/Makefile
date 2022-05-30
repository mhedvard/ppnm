Plot_erf.png:plot.ppl erf.dat erftab.dat
	pyxplot $<


Out.txt erf.dat:main.exe
	mono main.exe > Out.txt

main.exe:main.cs integrate.dll
	mcs -target:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

integrate.dll:integrate.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	rm *.dll *.exe *.png *.txt erf.dat
