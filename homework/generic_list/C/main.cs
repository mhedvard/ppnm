using System; 
using static System.Console;

public class main{
        public static void Main(){
		WriteLine("Test of list using chain of nodes"); 
                list<int> a = new list<int>();
                a.push(1);
                a.push(2);
                a.push(3);
                for( a.start(); a.current != null; a.next())
                        WriteLine(a.current.item);
		WriteLine("Test OK");
	} 
}
