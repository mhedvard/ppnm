Plot.png:plot.ppl RungePhen.dat
	pyxplot $<

Out.txt RungePhen.dat:main.exe
	mono main.exe > Out.txt

main.exe:main.cs akima.dll polyInt.dll
	mcs -target:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


akima.dll:akima.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


polyInt.dll:polyInt.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	$(RM) *.dll *.exe *.png *.txt *.dat
