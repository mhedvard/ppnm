Out.txt: main.exe
	mono main.exe < input.txt > Out.txt

main.exe: main.cs  genlist.dll
	mcs -target:exe -out:main.exe -r:genlist.dll main.cs

genlist.dll: genlist.cs
	mcs -target:library -out:genlist.dll genlist.cs

clean:
	rm -f [Oo]ut.txt *.exe *.dll
