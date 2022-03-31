public class genlist<T>{
	public T[] data; 
	public int size = 0, capacity = 8;  // property
	public genlist(){ data = new T[capacity];} // constructor
	public void push(T item) {
		if(size == capacity){
			T[] newdata = new T[capacity*=2];
			for (int i=0; i<size; i++)
				newdata[i] = data[i];
		}
		data[size] =item;
		size++;
	}

	public void remove(int i){
		T[] newdata = new T[capacity]; 
		for(int k=0; k<size; k++){	
			if(k<i)
				newdata[k] = data[k];
			else if(k>i)
				newdata[k-1]=data[k];
		}
		data = newdata;
		size--;
	}
}

