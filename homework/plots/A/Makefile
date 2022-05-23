Plot_erf.png:plot.ppl erf_val.dat
	pyxplot $<

erf_val.dat: main.exe
	mono main.exe > erf_val.dat

main.exe: main.cs
	mcs main.cs

clean:
	rm -f *.dll *.exe *.png *.txt erf_val.dat
