Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs cmath.dll
	mcs -reference:cmath.dll main.cs

cmath.dll: cmath.cs complex.cs
	mcs -target:library -out:cmath.dll $^
clean:
	rm -f *.dll *.exe  *.txt
