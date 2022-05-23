Plot_lngamma.png:plot_lngamma.ppl gamma_val.dat
	pyxplot $<

Plot_gamma.png:plot_gamma.ppl gamma_val.dat
	pyxplot $<

gamma_val.dat: main.exe
	mono main.exe > gamma_val.dat

main.exe: main.cs
	mcs main.cs

clean:
	rm -f *.png *.exe gamma_val.dat
