'erf_val.dat : error_function.exe
	mono error_function.exe > erf_val.dat

error_function.exe : error_function.cs
	mcs error_function.cs

clean:                          # a phoney target, no dependencies
	rm -f erf_val.txt error_function.exe  # remove secondary file
