public class genlist<T>{
	public T[] data; 
	public int size;
	public genlist(){
		data = new T[0];
		size = 0;
	} 

	public void push(T item){
		T[] newdata = new T[size+1]; 
		for(int i=0;i<size;i++)
			newdata[i] = data[i]; 
		newdata[size] = item;
		data = newdata;
		size++; 
	}
}

