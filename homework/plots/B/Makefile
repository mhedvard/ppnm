gamma_val.dat : gammafunc.exe
	mono gammafunc.exe > gamma_val.dat

gammafunc.exe : gammafunc.cs
	mcs gammafunc.cs

clean:                          # a phoney target, no dependencies
	rm -f gamma_val.dat gammafunc.exe  # remove secondary file
