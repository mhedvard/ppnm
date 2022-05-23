Out.txt:stdin.exe
	mono stdin.exe < input.txt > Out.txt

stdin.exe:stdin.cs
	mcs -target:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	rm -f *.dll *.exe [Oo]ut.txt
