Plot.png:plot.ppl testAkima.dat
	pyxplot $<

Out.txt testAkima.dat:main.exe
	mono main.exe > Out.txt

main.exe:main.cs akima.dll
	mcs -target:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

akima.dll:akima.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	$(RM) *.dll *.exe *.png *.txt *.dat
