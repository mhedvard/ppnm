Out.txt: main.exe               # out.txt depends on main.exe
	mono main.exe > Out.txt # run main.exe, send output to Out.txt

main.exe: main.cs               # maino.exe depends on main.cs
	mcs main.cs             # compile main.cs into main.exe

clean:                          # a phoney target, no dependencies
	rm -f [Oo]ut.txt main.exe  # remove secondary file
