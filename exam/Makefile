Plot_Wiggle.png:plot.ppl testWiggle.dat
	pyxplot $<

Out.txt testWiggle.dat:main.exe
	mono main.exe > Out.txt

main.exe:main.cs akima.dll cspline.dll
	mcs -target:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


akima.dll:akima.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


cspline.dll:cspline.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	$(RM) *.dll *.exe *.png *.txt *.dat
