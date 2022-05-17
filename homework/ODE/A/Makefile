Occilation.png:plot.ppl PendRes.dat
	pyxplot $<

Out.txt PendRes.dat:main.exe
	mono main.exe > Out.txt

main.exe:main.cs driver.dll vector.dll
	mcs -target:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

driver.dll:driver.cs vector.dll rkstep.dll
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

rkstep.dll:rkstep.cs vector.dll
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

vector.dll:vector.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	$(RM) *.dll *.exe *.png *.txt *.dat log*
