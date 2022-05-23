Out.txt:fileio.exe
	mono fileio.exe -input:input.txt -output:Out.txt

fileio.exe:fileio.cs
	mcs -target:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	rm -f *.dll *.exe [Oo]ut.txt
