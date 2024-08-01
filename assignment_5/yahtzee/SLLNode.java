package yahtzee;

public class SLLNode {
	private Object data;
	private SLLNode next;
	
	public void setData(Object input) {
		data = input;
	}
	
	public SLLNode getNext() {
		return next;
	}
	
	public Object getData() {
		return data;
	}
	
	public void setNext(SLLNode node) {
		next = node;
	}
}
