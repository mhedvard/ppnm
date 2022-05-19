Out.txt : hello.exe			# Out.txt depends on hello.exe
	mono hello.exe > Out.txt	# run hello.exe, send output to orut.txt

hello.exe : hello.cs			# hello.exe denpends on hello.cs
	mcs hello.cs			# compile hello.cs into hello.exe

clean:					# a phoney terget, no dependencies
	rm -f [Oo]ut.txt hello.exe		# remove secondary files
