complexG.dat : complexG.exe
	mono complexG.exe > conplexG.dat

complexG.exe : complexG.cs
	mcs complexG.cs

clean:                          # a phoney target, no dependencies
	rm -f complexG.dat compexG.exe  # remove secondary file
