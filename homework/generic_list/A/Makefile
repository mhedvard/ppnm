Out.txt : main.exe            
	mono main.exe > Out.txt 

main.exe : main.cs  genlist.dll            # maino.exe depends on main.cs
	mcs -target:exe -out:main.exe -referance:genlist.dll main.cs

genlist.dll: genlist.cs 
	mcs -target:library -out:genlist.dll genlist.cs

clean:                          # a phoney target, no dependencies
	rm -f out.txt main.exe  # remove secondary file
