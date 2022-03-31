Out.txt : main.exe            
	mono main.exe > Out.txt 

main.exe : main.cs  list.dll           
	mcs -target:exe -out:main.exe -r:list.dll main.cs

list.dll: list.cs 
	mcs -target:library -out:list.dll node.cs list.cs

node.dll: node.cs 
	mcs -target:library -out:node.dll node.cs

clean:
	$(RM) *.dll *.exe *.data
