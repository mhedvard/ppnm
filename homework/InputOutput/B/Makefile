Out.txt:cmdline.exe
	mono cmdline.exe 1 2 3 4 5 > Out.txt

cmdline.exe:cmdline.cs
	mcs -target:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	rm -f *.dll *.exe [Oo]ut.txt
