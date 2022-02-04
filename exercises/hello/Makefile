out.txt : hello.exe			# out.txt depends on hello.exe
	mono hello.exe > out.txt	# run hello.exe, send output to orut.txt

hello.exe : hello.cs			# hello.exe denpends on hello.cs
	mcs hello.cs			# compile hello.cs into hello.exe

clean:					# a phoney terget, no dependencies
	rm -f out.txt hello.exe		# remove secondary files
