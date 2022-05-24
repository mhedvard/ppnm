Plot.png:plot.ppl result.dat
	pyxplot $<

result.dat:main.exe
	mono main.exe > result.dat bcval.txt


main.exe:main.cs cspline.dll
	mcs -target:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


cspline.dll:cspline.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


clean:
	$(RM) *.dll *.exe *.png *.txt *.dat log*
