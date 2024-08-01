package fortune;

public class Queue {
	private Object[] elements;
	private int memberCount;
	private int capacity;
	private int head;
	private int tail;
	
	//constructor
	public Queue(int capacity) {
		elements = new Object[capacity];
		this.capacity = capacity;
		memberCount = 0;
		head = 0;
		tail = 1;
	}
	
	public void enqueue(Object object) {
		if (!isFull()) {
			memberCount++;
			if (tail==0) tail=capacity-1;
			else tail--;
			elements[tail] = object;
		}
	}
	
	public Object dequeue() {
		if (isEmpty()) return null;
		else {
			//take
			Object output = elements[head];
			if (head==0) head=capacity-1;
			else head--;
			memberCount--;
			
			//return
			return output;
		}
	}
	
	public Object peek() {
		if (isEmpty()) return null;
		else return elements[0];
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
