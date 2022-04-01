Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs harmonic_sum.dll
	mcs -target:exe -out:main.exe -reference:harmonic_sum.dll main.cs

harmonic_sum.dll: harmonic_sum.cs
	mcs -target:library -out:harmonic_sum.dll harmonic_sum.cs

clean:
	$(RM) *.dll *.exe *.data
