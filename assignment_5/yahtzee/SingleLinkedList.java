package yahtzee;

import java.io.FileWriter;
import java.io.IOException;

public class SingleLinkedList {
	private SLLNode head;
	
	public void add(Object data) {
		if (head == null) {
			head = new SLLNode();
			head.setData(data);
		}
		else {
			SLLNode node = head;
			while (true) {
				if (node.getNext() == null) {
					SLLNode newNode = new SLLNode();
					newNode.setData(data);
					node.setNext(newNode);
					break;
				}
				node = node.getNext();
			}
		}
	}
	
	public int count(Object data) {
		int counter = 0;
		SLLNode node = head;
		while (true) {
			if (node == null) break;
			if (node.getData().equals(data)) {
				counter++;
			}
			node = node.getNext();
		}
		return counter;
	}
	
	public void remove(Object data) {
		SLLNode node = head;
		//special case for 0 element
		if (head == null) return;
		
		//special case for 1 element
		if (head.getNext() == null) {
			if (head.getData().equals(data)) {
				head = null;
			}
			return;
		}
		
		while (true) {
			
			if (node.getData().equals(data)) {
				//remove element and close the gap
				while (true) {
					node.setData(node.getNext().getData());
					if (node.getNext().getNext() == null) break;
					node = node.getNext();
				}
				node.setNext(null);
				return;
			}
			
			//special case if found at last element
			if (node.getNext().getNext() == null) {
				if (node.getNext().getData().equals(data)) node.setNext(null);
				return;
			}
			
			node = node.getNext();
		}
	}
	
	public void view() {
		SLLNode node = head;
		while (true) {
			if (node == null) break;
			System.out.print(node.getData()+" ");
			node = node.getNext();
		}
	}
	
	public void insertSorted(String name, int score) {
		Object[] array = new Object[2];
		array[0] = name;
		array[1] = score;
		if (head == null) {
			head = new SLLNode();
			head.setData(array);
		}
		else if (head.getNext() == null) {
			if ((int)(((Object[]) head.getData())[1]) < score) {
				Object temp = head.getData();
				head.setNext(new SLLNode());
				head.getNext().setData(temp);
				head.setData(array);
			}
			else {
				head.setNext(new SLLNode());
				head.getNext().setData(array);
			}
		}
		else if ((int)(((Object[]) head.getData())[1]) < score) {
			SLLNode node = head;
			Object temp = node.getData();
			node.setData(array);
			while (true) {
				if (node.getNext() == null) {
					node.setNext(new SLLNode());
					node = node.getNext();
					node.setData(temp);
					break;
				}
				node = node.getNext();
				Object toTemp = node.getData();
				node.setData(temp);
				temp = toTemp;
			}
		}
		else {
			SLLNode node = head;
			while (true) {
				if (node.getNext() == null) {
					SLLNode newNode = new SLLNode();
					newNode.setData(array);
					node.setNext(newNode);
					break;
				}
				if ((int)(((Object[]) node.getNext().getData())[1]) < score) {
					node = node.getNext();
					Object temp = node.getData();
					node.setData(array);
					while (true) {
						if (node.getNext() == null) {
							node.setNext(new SLLNode());
							node = node.getNext();
							node.setData(temp);
							break;
						}
						node = node.getNext();
						Object toTemp = node.getData();
						node.setData(temp);
						temp = toTemp;
					}
					break;
				}
				node = node.getNext();
			}
		}
	}
	
	public void viewSorted() {
		SLLNode node = head;
		while (true) {
			if (node == null) break;
			System.out.println(((Object[])(node.getData()))[0]+" "+((Object[])(node.getData()))[1]);
			node = node.getNext();
		}
	}
	
	public void removeScore(String name) {
		SLLNode node = head;
		//special case for 0 element
		if (head == null) return;
		
		//special case for 1 element
		if (head.getNext() == null) {
			if (((Object[])(node.getData()))[0].equals(name)) {
				head = null;
			}
			return;
		}
		
		while (true) {
			
			if (((Object[])(node.getData()))[0].equals(name)) {
				//remove element and close the gap
				while (true) {
					node.setData(node.getNext().getData());
					if (node.getNext().getNext() == null) break;
					node = node.getNext();
				}
				node.setNext(null);
				return;
			}
			
			//special case if found at last element 
			if (node.getNext().getNext() == null) {
				if (((Object[])(node.getNext().getData()))[0].equals(name)) node.setNext(null);
				return;
			}
			
			node = node.getNext();
		}
	}
	
	public void saveToFile(String file) {
		try {
			int i = 0;
			FileWriter writer = new FileWriter("HighScoreTable.txt");
			String text = "";
			SLLNode node = head;
			while (true) {
				String writtenName = (String)((Object[])(node.getData()))[0];
				int writtenScore = (int) ((Object[])(node.getData()))[1];
				
				if (i<10) {	
					System.out.print(writtenName+" ");
					System.out.println(writtenScore);
					i++;
				}
				text = text + writtenName + "\n" + writtenScore + "\n";
				
				if (node.getNext() != null) {
					node = node.getNext();
				}
				else break;
			}
			writer.write(text);
			writer.close();
		} catch (IOException e) {}
	}
}
