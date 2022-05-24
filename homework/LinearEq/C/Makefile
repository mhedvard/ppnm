Plot.png:plot.ppl results.dat
	pyxplot $<

results.dat:main.exe
	mono main.exe > results.dat

main.exe:main.cs matrix.dll QRGS.dll vector.dll
	mcs -target:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


QRGS.dll:QRGS.cs matrix.dll vector.dll
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

matrix.dll:matrix.cs vector.dll
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

vector.dll:vector.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	$(RM) *.dll *.exe *.png *.txt *.dat
