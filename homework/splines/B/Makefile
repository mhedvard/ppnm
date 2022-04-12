plot.png:plot.ppl result.dat
	pyxplot $<

results.dat:main.exe
	mono main.exe > result.dat


main.exe:main.cs qspline.dll
	mcs -target:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


qspline.dll:qspline.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


clean:
	$(RM) *.dll *.exe *.png *.txt *.dat log*
