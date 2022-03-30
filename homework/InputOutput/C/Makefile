CSC = mcs

fileio.exe: fileio.cs 

%.exe: %.cs
	$(CSC) -target:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	$(CSC) -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)
