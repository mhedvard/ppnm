Report.pdf:report.txt ex_plot.png
	pdflatex $<

ex_plot.png:ex_plot.ppl ex.dat
	pyxplot $<

ex.dat:main.exe
	mono main.exe > ex.dat

main.exe:main.cs
	mcs main.cs


clean:
	rm -f *.dll *.exe  *.dat *.pdf *.aux *.png *.log *.out
