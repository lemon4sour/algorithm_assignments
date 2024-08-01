package fortune;

public class Stack {
	private Object[] elements;
	private int memberCount;
	private int capacity;
	
	//constructor
	public Stack(int capacity) {
		elements = new Object[capacity];
		this.capacity = capacity;
		memberCount = 0;
	}
	
	public void push(Object object) {
		if (!isFull()) {
			elements[memberCount] = object;
			memberCount++;
		}
	}
	
	public Object pop() {
		if (isEmpty()) return null;
		else {
			//take
			Object output = elements[memberCount-1];
			elements[memberCount-1] = null;
			memberCount--;
			
			//return
			return output;
		}
	}
	
	public Object peek() {
		if (isEmpty()) return null;
		else return elements[memberCount-1];
	}
	
	public boolean isFull() {
		if (memberCount == capacity) return true;
		else return false;
	}
	
	public boolean isEmpty() {
		if (memberCount == 0) return true;
		else return false;
	}
	
	public int size() {
		return memberCount;
	}

}
