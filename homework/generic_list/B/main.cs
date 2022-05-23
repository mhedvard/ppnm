using System; 
using static System.Console;

class main{
	static public void Main(){
		var list = new genlist <double[]>(); 
		char[] delimiters = {' ','\t'};
		var options = StringSplitOptions.RemoveEmptyEntries; 
		
		for(string line = ReadLine(); line!=null; line=ReadLine()){
			var words = line.Split(delimiters,options); 
			int n = words.Length;
			var numbers = new double[n]; 
			for(int i=0; i<n; i++) 
				numbers[i] = double.Parse(words[i]); 
			list.push(numbers); 
		}
		
		for(int i=0; i<list.size;i++){
			var numbers = list.data[i];
			foreach(var number in numbers)
				Write($"{number} ");
			WriteLine("");
		}
		WriteLine(""); 

		/* Remove list n */
		int i_remove = 1; // Index of list to remove
		list.remove(i_remove); 

		WriteLine($"List of index {i_remove} is remowed");
		
		for(int i=0; i<list.size; i++){
			var numbers = list.data[i];
			foreach(var number in numbers)
				Write($"{number} ");
			WriteLine();
		}
		
		
	}
}
